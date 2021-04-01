using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Experience1
{
    public class DataStore
    {
        private const string connectionString = "Data Source=BEYN1231;Initial Catalog=DB1;Integrated Security=true";

        private void ExecuteSqlReader(string query, Action<SqlDataReader> action)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        action(reader);
                    }

                    reader.Close();
                }
            }
        }

        public IEnumerable<Contact> GetContacts()
        {
            var contacts = new List<Contact>();

            ExecuteSqlReader("Select * from Contact,Country", reader =>
            {
                var contact = new Contact
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    CountryId = (int)reader["CountryId"],
                    //Country  = 
                };

                contacts.Add(contact);
            });

            return contacts;
        }

        public Contact GetContact(int id)
        {
            Contact contact = null;

            ExecuteSqlReader($"SELECT * FROM Contact WHERE Id={id}", reader =>
            {
                contact = new Contact
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    CountryId = (int)reader["CountryId"]
                };
            });

            return contact;
        }

        public IEnumerable<Contact> GetContacts2()
        {
            var contacts = new List<Contact>();
            var countries = new List<Country>();

            ExecuteSqlReader(@"SELECT        c.Id, c.Name, c.Email, cu.Id , cu.Name 
                               FROM            Contact AS c INNER JOIN
                                               Country AS cu ON c.CountryId = cu.Id", reader =>
            {
                var contact = new Contact
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"],
                    Email = (string)reader["Email"],
                    CountryId = (int)reader["CountryId"],

                };
                contacts.Add(contact);
                var country = new Country
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]

                };
                countries.Add(country);


            });

            var thisContactCountry = countries
                .GroupBy(m => m.Id)
                .Select(m =>
                {
                    var sssss = contacts.Where(a => a.CountryId==m.Key);

                    var c = new Country();
                    return c;
                });
            return contacts;
        }


    }
}