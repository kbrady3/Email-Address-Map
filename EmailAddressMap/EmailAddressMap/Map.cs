using System;
using System.Collections.Generic;
using System.Text;

namespace EmailAddressMap
{
    public class Map
    {
        private string[] Key { get; set; }
        private string[] Value { get; set; }
        private int Max { get; set; }

        public Map() {
        
        }

        public Map(string[] key, string[] value, int max)
        {
            if(key.Length != value.Length)
            {
                throw new ArgumentException("Key and value arrays must be the same length.");
            }

            Value = value;
            Key = key; //Initialize array with provided keys before sending to Hash() method
            Max = max;

            //Populate the Key array with hashed keys
            for (int i = 0; i < key.Length; i++)
            {
                Key[i] = Hash(key[i], Max).ToString();
            }
        }

        public static int Hash(string key, int max)
        {
            int h = 0;
            for (int i = 0; i < key.Length; i++)
            {
                h += key[i] * (max - 1);
            }
            return h % max;
        }

        public string Print()
        {
            string container = "";
            for(int i = 0; i < Key.Length; i++)
            {
                container += "Key: " + Key[i] + ", Value: " + Value[i] + "\n";
            }

            return container;
        }
    }
}
