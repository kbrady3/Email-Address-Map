using System;

namespace EmailAddressMap
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] emails = { "example@mail.com" };
            string[] names = { "Marjorie Smith" };
            Map m = new Map(emails, names, 5);
        }
    }
}
