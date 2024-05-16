namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public string PossibleQuestion { get; set; }
        public List<Option> Options { get; set; }
    }
}
