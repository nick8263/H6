namespace Models
{
    public class Country : Common
    {
        public int CountryId { get; set; }
        public string? PossibleCountry { get; set; }

        private int test;

        public int getTest()
        {
            return test;
        }

        public void setTest(int i)
        {
            test = i;
        }
    }
}
