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
        // Class Fields
        private byte[] randomNumbers;

        // Default constructor
        public ShuffleHeaven()
        {
            int maxNumbers = 14;
            // Generates 10 random numbers
            using (RNGCryptoServiceProvider crng = new RNGCryptoServiceProvider())
            {
                randomNumbers = new byte[maxNumbers];

                for(int i = 1; i <= maxNumbers; i++)
                {
                    crng.GetBytes(randomNumbers);

                    int value = BitConverter.ToInt32(randomNumbers, 0);
                    Console.WriteLine(i.ToString() + ")" + value);
                }
            }
        }

        
    }
}
