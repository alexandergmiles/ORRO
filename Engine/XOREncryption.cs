using Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine
{
    public class XOREncryption : IEncryption
    {
        public string DecryptResponse(string responseString)
        {
            //The magic number again
            int key = 0xAB;

            //Where we store the response value
            StringBuilder response = new StringBuilder();

            //For every character in the response
            for (int i = 0; i < responseString.Length; i++)
            {
                //Do our conversion as we did before
                response.Append(Convert.ToChar(responseString[i] ^ key));
                key = Convert.ToChar(responseString[i]);
            }

            //Return the decrypted value
            return response.ToString();
        }

        public string EncryptCommand(string commandString)
        {
            //Our initial key value - I wonder where TP-LINK grabbed this from
            int key = 0xAB;

            //Where we're going to store the encrypted message
            StringBuilder commandToSendToDevice = new StringBuilder();

            //String needs to be in Latin1 encoding
            var encoded = Encoding.GetEncoding("ISO-8859-1").GetString(Encoding.GetEncoding("ISO-8859-1").GetBytes(commandString));

            //We need to encode every character in the command string
            for (int i = 0; i < commandString.Length; i++)
            {
                //Take the current character and convert it to its int representation
                var intCommand = Convert.ToInt32(commandString[i]);

                //XOR the int value of the character with the key
                commandToSendToDevice.Append(Convert.ToChar(intCommand ^ key));

                //Set the key to the Char value of the intCommand XOR'd with the previous key
                key = Convert.ToInt32(Convert.ToChar(intCommand ^ key));
            }

            //Return the result of the encryption
            return commandToSendToDevice.ToString();
        }
    }
}
