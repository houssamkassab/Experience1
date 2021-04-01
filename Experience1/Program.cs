using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;


namespace Experience1
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataStore = new DataStore();


            var contacts = dataStore.GetContacts();
            var ibra = dataStore.GetContact(3);

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }

            Console.WriteLine(ibra);
            Console.WriteLine(ibra);
            Console.ReadKey();
        }
    }
}
