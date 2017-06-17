using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Randee
{
    class ShuffleHeaven
    {
        /* Class Members */

        private static RNGCryptoServiceProvider crng    = new RNGCryptoServiceProvider();
        private static System.Random prng               = new System.Random();
        private static WebClient webClient              = new WebClient();

        /* 'ShuffleHeaven' constants */
        private static readonly string REQUEST_ID       = "1414";

        /* Random.org Information */
        private static int bitsLeft;
        private static int requestsLeft;

        private static string numbers;
        private static DateTime sessionStartTime = DateTime.Now.ToUniversalTime();
        private static DateTime advisedRequestTime;
        private static DateTime defaultDateTime;

        private static bool exceptionThrown;
        


        /* Default Constructor */

        public ShuffleHeaven()
        {
            // do nothing for now
        }



        /* Main Functions */



        /*
         * Generates 'numberOfNumbers' pseudo random number(s) between the range of 'minRange' and 'maxRange'
         */
        public static List<int> GeneratePseudoRandomNumber(int numberOfNumbers, int minRange, int maxRange)
        {
            System.Random sprng = new System.Random();
            List<int> result = new List<int>();

            for(int numbersAdded = 0; numbersAdded < numberOfNumbers; numbersAdded++)
            {
                result.Add(sprng.Next(minRange, maxRange));
            }

            return result;
        }



        /// <summary>
        /// Use the Random.org API to generate random numbers.
        /// 
        /// Guidelines: (https://api.random.org/guidelines)
        /// 1) If possible, do not issue multiple simultaneous requests (Doesn't matter if client is single-threaded).
        /// 2) Fetch numbers in blocks as large as possible, this is more efficient than issuing a separate request for every single number.
        /// 3) If the client is not a real-time application, use a long timeout value for your requests, ideally a couple of minutes.
        /// 4) If the daily request or bit limit is exceeded, the client must back off until midnight UTC. Random.org will respond with a
        ///    402 or 403 error code, if your API key does not have enough requests or bits left. Your key's current usage is included in nearly all API
        ///    responses, so the client can easily track how many of each it has left.
        /// 5) Obey the advisory delays requested by Random.org in the API responses.
        /// </summary>
        /// <param name="numberOfNumbers"></param>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        public static List<int> GetTrueRandomNumber(int numberOfNumbers, int minRange, int maxRange)
        {
            numbers = "";
            SetExceptionThrown(false);

            if (GetRequestsLeft() == 0) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);
            if (GetBitsLeft() <= 0) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);
            if (GetAdvisedRequestTime() != defaultDateTime && DateTime.Now.ToUniversalTime() < GetAdvisedRequestTime()) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);

            string response = "";

            try
            {
                response = webClient.UploadString("https://api.random.org/json-rpc/1/invoke",
                "{\"jsonrpc\":\"2.0\",\"method\":\"generateIntegers\",\"params\":{\"apiKey\":\""
                + Environment.GetEnvironmentVariable("RANDOM_ORG_API", EnvironmentVariableTarget.User) + "\",\"n\":"
                + numberOfNumbers.ToString() + ",\"min\":" + minRange.ToString() + ",\"max\":" + maxRange.ToString()
                + ",\"replacement\":true,\"base\":10},\"id\":" + REQUEST_ID + "}");
            }
            catch (WebException)
            {
                SetExceptionThrown(true);

                return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);
            }

            TrueRandomObject tro = JsonConvert.DeserializeObject<TrueRandomObject>(response);

            SetBitsLeft(tro.result.bitsLeft);
            SetRequestsLeft(tro.result.requestsLeft);
            SetAdvisedRequestTime(tro.result.advisoryDelay);

            return tro.result.random.data;
        }



        /* Returns information related to the usage of the set API Key. */
        public static void GetUsage()
        {
            SetExceptionThrown(false);

            try
            {
                string usage = webClient.UploadString("https://api.random.org/json-rpc/1/invoke",
                "{\"jsonrpc\":\"2.0\",\"method\":\"getUsage\",\"params\":{\"apiKey\":\""
                + Environment.GetEnvironmentVariable("RANDOM_ORG_API", EnvironmentVariableTarget.User) + "\"},\"id\":" + REQUEST_ID + "}");

                TrueRandomObject tro = JsonConvert.DeserializeObject<TrueRandomObject>(usage);

                SetBitsLeft(tro.result.bitsLeft);
                SetRequestsLeft(tro.result.requestsLeft);
            }
            catch (WebException)
            {
                SetExceptionThrown(true);
            }
        }



        /* Getters & Setters */
        public static int GetBitsLeft()
        {
            return bitsLeft;
        }

        private static void SetBitsLeft(int bitsRemaining)
        {
            bitsLeft = bitsRemaining;
        }



        public static int GetRequestsLeft()
        {
            return requestsLeft;
        }

        private static void SetRequestsLeft(int requestsRemaining)
        {
            requestsLeft = requestsRemaining;
        }



        private static DateTime GetAdvisedRequestTime()
        {
            return advisedRequestTime;
        }

        private static void SetAdvisedRequestTime(int advisoryDelay)
        {
            advisedRequestTime = DateTime.Now.ToUniversalTime().AddMilliseconds(advisoryDelay);
        }



        public static bool GetExceptionThrown()
        {
            return exceptionThrown;
        }

        private static void SetExceptionThrown(bool exceptionThrownValue)
        {
            exceptionThrown = exceptionThrownValue;
        }
    }
}
