using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Randee
{
    class ShuffleHeaven
    {
        /* Class Members */

        private static RNGCryptoServiceProvider crng    = new RNGCryptoServiceProvider();
        private static Random prng                      = new Random(); 



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
            Console.WriteLine("Calling GenerateSmallNumber()");

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
        public static int GenerateNumber(int minRange, int maxRange)
        {
            Console.WriteLine("Calling GenerateNumber()");
            Random sprng = new Random(GenerateSeed());
            
            return sprng.Next(minRange, maxRange);
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
    }
}
