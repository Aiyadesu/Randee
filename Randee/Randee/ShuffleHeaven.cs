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
        /* Class Fields */
        private static RNGCryptoServiceProvider crng = new RNGCryptoServiceProvider();

        private byte[] randomNumbers;



        /* Default Constructor */
        public ShuffleHeaven()
        {
            randomNumbers = new byte[14];
            for(int i = 0; i < 14; i++)
            {
                randomNumbers[i] = GenerateNumber(100);
            }

            foreach(byte number in randomNumbers)
            {
                Console.WriteLine(number);
            }
        }

        /* Main Functions */



        // Use to generate a random number between the range of 1 and the 'maxRange'.
        // The input parameter is the 'maxRange' i.e To simulate rolling a 6-sided you would input "6" as the 'maxRange' parameter.
        public static byte GenerateNumber(byte maxRange)
        {
            if(maxRange <= 0)
            {
                throw new ArgumentOutOfRangeException("maxRange is invalid! Cannot be less than or equal to 0");
            }

            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[1]; 

            do
            {
                // Fill the array with a random value.
                crng.GetBytes(randomNumber);
            }

            while (!IsUniformlyDistributed(randomNumber[0], maxRange));

            return (byte)((randomNumber[0] % maxRange) + 1); // Adjusted for zero-indexed memery
        }

        /* Helper Functions */



        // Use to ensure each random number returned has an equal probability of occurring i.e "Uniformly Distributed"
        // Ripped from https://msdn.microsoft.com/en-us/library/system.security.cryptography.rngcryptoserviceprovider(v=vs.110).aspx
        private static bool IsUniformlyDistributed(byte roll, byte numSides)
        {
            int fullSetsOfValues = Byte.MaxValue / numSides;

            return roll < numSides * fullSetsOfValues;
        }

        
    }
}
