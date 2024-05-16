namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public string PossibleQuestion { get; set; }
        public string FreeTextAnswer { get; set; }
        public List<Option> Options { get; set; }
        public List<QuestionGroup> questionGroups { get; set; }
    }
}
