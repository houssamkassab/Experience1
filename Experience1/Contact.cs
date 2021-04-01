namespace Experience1
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int CountryId { get; set; }

        public Country Country { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name} - {Email} - {CountryId}";
        }
    }
}
