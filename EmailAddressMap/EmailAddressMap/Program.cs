using System;

namespace EmailAddressMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = { "example@mail.com", "test@mail.com", "me@mail.com", "you@mail.com" };
            string[] names = { "Marjorie Smith" , "Bailey Estra", "Sam Smiley", "Bob Robert" };
            Map m = new Map(emails, names, 78542);

            Console.WriteLine(m.Print());
        }
    }
}
