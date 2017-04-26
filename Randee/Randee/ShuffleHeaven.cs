using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;

namespace Randee
{
    class ShuffleHeaven
    {
        /* Class Members */

        private static RNGCryptoServiceProvider crng    = new RNGCryptoServiceProvider();
        private static Random prng                      = new Random();
        private static WebClient webClient              = new WebClient();

        /* Random.org Information */
        private static int bitsLeft;
        private static int requestsLeft;
        private static int advisoryDelay;

        private static string numbers;
        


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
        public static string GenerateNumber(int numberOfNumbers, int minRange, int maxRange)
        {
            string numbers = "";

            Random sprng = new Random(GenerateSeed());

            if(numberOfNumbers == 1)
            {
                return sprng.Next(minRange, maxRange).ToString();
            }

            for (int number = 0; number < numberOfNumbers; number++)
            {
                numbers += sprng.Next(minRange, maxRange).ToString() + ",";
            }

            return numbers.Remove(numbers.Length - 1);
        }



        /* Helper Functions */



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
        /// 3) If the  client is not a real-time application, use a long timeout value for your requests, ideally a couple of minutes.
        /// 4) If the daily request or bit limit is exceeded, the client must back off until midnight UTC. Random.org will respond with a
        ///    402 or 403 error code, if your API key does not have enough requests or bits left. Your key's current usage is included in nearly all API
        ///    responses, so the client can easily track how many of each it has left.
        /// 5) Obey the advisory delays requested by Random.org in the API responses.
        /// </summary>
        /// <param name="numberOfNumbers"></param>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        public static string GetTrueRandomNumber(int numberOfNumbers, int minRange, int maxRange)
        {
            string requestID = "1414";

            string response = webClient.UploadString("https://api.random.org/json-rpc/1/invoke", 
                "{\"jsonrpc\":\"2.0\",\"method\":\"generateIntegers\",\"params\":{\"apiKey\":\"" 
                + Environment.GetEnvironmentVariable("RANDOM_ORG_API", EnvironmentVariableTarget.User) + "\",\"n\":"
                + numberOfNumbers.ToString() + ",\"min\":" + minRange.ToString() + ",\"max\":" + maxRange.ToString() 
                + ",\"replacement\":true,\"base\":10},\"id\":" + requestID + "}");


            ExtractInformationFromResponse(response);

            return numbers;
        }



        /* 
         * Avoid reading this function, just trust it works.
         * This is why people use JSON.NET.
         */
        private static void ExtractInformationFromResponse(string response)
        {
            /* Store the numbers data */
            string numbersData = response.Remove(response.IndexOf("]"));

            numbers = numbersData.Substring(response.IndexOf("[") + 1);



            /* Stores the 'usage' information */
            int usageInfoStartIndex = response.IndexOf("\"bitsLeft");
            int usageInfoEndIndex = response.LastIndexOf(",");

            // Separates the 'usage' from the response
            string usageInfo = response.Substring(usageInfoStartIndex, usageInfoEndIndex - usageInfoStartIndex);

            // Separates the 'bitsLeft' info from the response
            string bitsLeftStr = usageInfo.Remove(usageInfo.IndexOf(","));
            usageInfo = usageInfo.Substring(usageInfo.IndexOf(",") + 1);

            // Separates the 'requestsLeft' info from the response
            string requestsLeftStr = usageInfo.Remove(usageInfo.IndexOf(","));

            // Separates the 'advisoryDelay' info from the response
            string advisoryDelayStr = usageInfo.Substring(usageInfo.IndexOf(",") + 1);
            advisoryDelayStr = advisoryDelayStr.Remove(advisoryDelayStr.Length - 1);
 


            /* Store the info as the proper data type */
            bitsLeft = Int32.Parse(bitsLeftStr.Substring(bitsLeftStr.IndexOf(":") + 1));
            requestsLeft = Int32.Parse(requestsLeftStr.Substring(requestsLeftStr.IndexOf(":") + 1));
            advisoryDelay = Int32.Parse(advisoryDelayStr.Substring(advisoryDelayStr.IndexOf(":") + 1));
        }



        /* Getters & Setters */
        private static int GetBitsLeft()
        {
            return bitsLeft;
        }

        private static void SetBitsLeft(int bitsRemaining)
        {
            bitsLeft = bitsRemaining;
        }

        private static int GetRequestsLeft()
        {
            return requestsLeft;
        }

        private static void SetRequestsLeft(int requestsRemaining)
        {
            requestsLeft = requestsRemaining;
        }

        private static int GetAdvisoryDelay()
        {
            return advisoryDelay;
        }

        private static void SetAdvisoryDelay(int advisedDelay)
        {
            advisoryDelay = advisedDelay;
        }
    }
}
