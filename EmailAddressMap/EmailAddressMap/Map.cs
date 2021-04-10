//This map uses 3 primary lists: NonHashedKeys, Key, and Value. NonHashedKeys stores sensitive information and is not directly accessible to the user. This list is necessary for finding values that already exist, because users won't be searching by hashed keys, they'll be searching by the unencrypted keys.

using System;
using System.Collections.Generic;
using System.Text;

namespace EmailAddressMap
{
    public class Map
    {
        private List<string> NonHashedKeys { get; set; }
        private List<int> Key { get; set; }
        private List<string> Value { get; set; }
        private List<int> EmptyList = new List<int>() { 0 }; //Used to initialize Key so it won't throw a null error
        private int Max { get; set; }

        public Map() {
        
        }

        public Map(List<string> key, List<string> value, int max)
        {
            Key = EmptyList; //Initialize Key so it won't throw a null error

            if (key.Count != value.Count)
            {
                throw new ArgumentException("Key and value lists must be the same length.");
            }

            NonHashedKeys = key;
            Value = value;
            Max = max;

            //Populate the Key array with hashed keys
            for (int i = 0; i < key.Count; i++)
            {
                Key.Add(Hash(key[i], Max));
            }

            Key.RemoveAt(0);
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

        public void Insert(string k, string v)
        {
            if (NonHashedKeys.Contains(k))
            {
                throw new ArgumentException("Key already exists.");
            }
            else
            {
                NonHashedKeys.Add(k);
                int keyHashed = Hash(k, Max);
                Key.Add(keyHashed);
                Value.Add(v);
            }
        }

        public void Remove(string k)
        {
            if (!NonHashedKeys.Contains(k))
            {
                throw new ArgumentException("Key doesn't exist.");
            }
            else
            {
                int keyIndex = NonHashedKeys.IndexOf(k);
                NonHashedKeys.RemoveAt(keyIndex);
                Key.RemoveAt(keyIndex);
                Value.RemoveAt(keyIndex);
            }
        }

        public void RemoveAll()
        {
            Key.Clear();
            Value.Clear();
            NonHashedKeys.Clear();
        }

        public bool HasKey(string valueToSearch)
        {
            if (Value.Contains(valueToSearch))
            {
                int keyIndex = Value.IndexOf(valueToSearch); //Since Key/Value are parallel arrays, gets the index of provided value and then gets the index of the corresponding key

                if (Key[keyIndex] != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentException("The given value doesn't exist.");
            }
        }

        public string FindValue(string keyToSearch)
        {
            if (NonHashedKeys.Contains(keyToSearch))
            {
                int valueIndex = NonHashedKeys.IndexOf(keyToSearch);
                return Value[valueIndex];
            }
            else
            {
                throw new ArgumentException("The given key doesn't exist.");
            }
        }

        public string Print()
        {
            string container = "";
            for(int i = 0; i < Key.Count; i++)
            {
                container += "Key: " + Key[i] + ", Value: " + Value[i] + "\n";
            }

            return container;
        }
    }
}
