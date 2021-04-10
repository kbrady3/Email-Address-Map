using System;
using System.Collections.Generic;

namespace EmailAddressMap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instead of using multiple Add methods to get all the values into the lists, I created arrays and used for loops to populate the lists. In my opinion, simply adding to an array by typing in the value is easier than using List.Add().

            string[] emailsArray = { "example@mail.com", "test@mail.com", "me@mail.com", "you@mail.com" };
            string[] namesArray = { "Marjorie Smith", "Bailey Estra", "Sam Smiley", "Bob Robert" };
            List<string> emails = new List<string>();
            List<string> names = new List<string>();

            for(int i = 0; i < emailsArray.Length; i++)
            {
                emails.Add(emailsArray[i]);
            }

            for (int i = 0; i < namesArray.Length; i++)
            {
                names.Add(namesArray[i]);
            }

            Map m = new Map(emails, names, 78542);

            Console.WriteLine(m.Print());
        }
    }
}
