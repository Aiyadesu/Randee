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

        /* Random.org Information */
        private static int bitsLeft = 250000;
        private static int requestsLeft = 1000;

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
         * Generates a number between the range of 'minRange' and 'maxRange'.
         * 
         * 'minRange' is the smallest number that can be generated.
         * 'maxRange' is the largest number that can be generated.
         */
        public static byte GenerateNumber(byte minRange, byte maxRange)
        {
            if(minRange <= 0 || maxRange <= 0)
            {
                throw new ArgumentOutOfRangeException("maxRange is invalid! Cannot be less than or equal to 0");
            }

            // Swaps the 'minRange' and 'maxRange' values, if 'minRange' is larger than 'maxRange'
            if(minRange > maxRange)
            {
                byte temp = minRange;

                minRange = maxRange;
                maxRange = temp;
            }

            // Create a byte array to hold the random value
            byte[] randomNumber = new byte[1];

            // Simplies the min and max values to a range starting from 1
            byte range = (byte)(maxRange - minRange + 1);

            /* Generate a random number that is considered "fair" */
            do
            {
                // Fill the array with a random value.
                crng.GetBytes(randomNumber);
            }

            while (!IsUniformlyDistributed(randomNumber[0], range)); 

            return (byte)((randomNumber[0] % range) + minRange); // Offsets the simplied range starting from 1 to start from the 'minRange'
        }

        /*
         * Generates multiple random numbers between the range of 'minRange' and 'maxRange'.
         * 
         * 'rolls' is the number of times a random number will be generated.
         * 'minRange' is the smallest number that can be generated.
         * 'maxRange' is the largest number that can be generated.
         */
        public static byte[] GenerateNumber(byte rolls, byte minRange, byte maxRange)
        {
            // Create a byte array to hold the results
            byte[] results = new byte[rolls];

            // Stores a random number in an array
            for(int roll = 0; roll < rolls; roll++)
            {
                results[roll] = GenerateNumber(minRange, maxRange);
            }

            return results;
        }



        /*
         * Generates a pseudo random number between the range of 'minRange' and 'maxRange'
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



        /* Helper Functions */



        /* Returns information related to the usage of the set API Key. */
        public static void GetUsage()
        {
            SetExceptionThrown(false);
            string requestID = "1414";

            try
            {
                string usage = webClient.UploadString("https://api.random.org/json-rpc/1/invoke",
                "{\"jsonrpc\":\"2.0\",\"method\":\"getUsage\",\"params\":{\"apiKey\":\""
                + Environment.GetEnvironmentVariable("RANDOM_ORG_API", EnvironmentVariableTarget.User) + "\"},\"id\":" + requestID + "}");

                TrueRandomObject tro = JsonConvert.DeserializeObject<TrueRandomObject>(usage);

                SetBitsLeft(tro.result.bitsLeft);
                SetRequestsLeft(tro.result.requestsLeft);
            }
            catch (WebException)
            {
                SetExceptionThrown(true);
            }
        }

        /*
         * Checks that the random number would be generated if each number had an equal probability of occuring.
         * 
         * Source: https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider(v=vs.110).aspx
         */
        private static bool IsUniformlyDistributed(byte roll, byte numSides)
        {
            int fullSetsOfValues = Byte.MaxValue / numSides;

            return roll < numSides * fullSetsOfValues;
        }



        /*
         * Generates a random seed
         */
        private static int GenerateSeed()
        {
            // Generates a cryptographically secure random number between the range of 0 and 255
            byte[] randomNumber = new byte[1];

            crng.GetBytes(randomNumber);

            // Generates a non-negative range from two pseudo random numbers
            int lowerLimit = prng.Next(int.MaxValue);
            int upperLimit = prng.Next(lowerLimit, int.MaxValue);

            // Create a seed using the pseudo random range, the current time and the cryptographically secure random number
            long seed = (prng.Next(lowerLimit, upperLimit) + DateTime.Now.Ticks) * (randomNumber[0] + 1);

            return (int) seed;
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

            if(DateTime.Now.ToUniversalTime().Day > sessionStartTime.Day)
            {
                SetRequestsLeft(1000);
                SetBitsLeft(250000);
            }

            if (GetRequestsLeft() == 0) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);
            if (GetBitsLeft() <= 0) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);
            if (GetAdvisedRequestTime() != defaultDateTime && DateTime.Now.ToUniversalTime() < GetAdvisedRequestTime()) return GeneratePseudoRandomNumber(numberOfNumbers, minRange, maxRange);

           
            string requestID = "1414";

            string response = "";

            try
            {
                response = webClient.UploadString("https://api.random.org/json-rpc/1/invoke",
                "{\"jsonrpc\":\"2.0\",\"method\":\"generateIntegers\",\"params\":{\"apiKey\":\""
                + Environment.GetEnvironmentVariable("RANDOM_ORG_API", EnvironmentVariableTarget.User) + "\",\"n\":"
                + numberOfNumbers.ToString() + ",\"min\":" + minRange.ToString() + ",\"max\":" + maxRange.ToString()
                + ",\"replacement\":true,\"base\":10},\"id\":" + requestID + "}");
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

            foreach (int number in tro.result.random.data)
            {
                numbers += number + ",";
            }

            return tro.result.random.data;
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
