using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ServiceBase.Services
{
    public class EncryptionService
    {
        public string GenerateSalt(int size = 10)
        {
            // Generate a cryptographic random number using the cryptographic 
            // service provider
            var rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number
            return Convert.ToBase64String(buff);
        }

        public string GenerateHash(string input)
        {
            // Create a new instance of the hash crypto service provider.
            var hashAlg = new SHA256CryptoServiceProvider();
            
            // Convert the data to hash to an array of Bytes.
            byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(input);
            
            // Compute the Hash. This returns an array of Bytes.
            byte[] bytHash = hashAlg.ComputeHash(bytValue);
            
            // Optionally, represent the hash value as a base64-encoded string, 
            // For example, if you need to display the value or transmit it over a network.
            return Convert.ToBase64String(bytHash);
        }
    }
}
