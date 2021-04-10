using System;
using System.Collections.Generic;

namespace EmailAddressMap
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create empty map
            List<string> emptyKey = new List<string>();
            List<string> emptyValue = new List<string>();
            Map emptyMap = new Map(emptyKey, emptyValue, 0);


            //Instead of using multiple Add methods to get all the values into the lists, I created arrays and used for loops to populate the lists. In my opinion, simply adding to an array by typing in the values is easier than using List.Add().
            string[] emailsArray = { "example@mail.com", "test@mail.com", "", "you@mail.com" };
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
            Console.WriteLine("Sam Smiley has an associated key: " + m.HasKey("Sam Smiley") + "\n");
            //Search for 2 people by key
            Console.WriteLine("Find value associated with 'test@mail.com': " + m.FindValue("test@mail.com") + "\n");
            Console.WriteLine("Find value associated with 'you@mail.com': " + m.FindValue("you@mail.com") + "\n");
            //Add 3 people
            m.Insert("i@example.com", "George Larrius");
            m.Insert("tu@mail.com", "Sally Lu");
            m.Insert("mi@mail.com", "Alex Shu");
            Console.WriteLine("New items added, new list below: \n" + m.Print() + "\n");
            m.Remove("mi@mail.com");
            Console.WriteLine("Previously added item removed, new list below: \n" + m.Print() + "\n");

            m.RemoveAll();

            Console.WriteLine("All values removed. List is now empty, as proven here (nothing should show up): " + m.Print());
        }
    }
}
