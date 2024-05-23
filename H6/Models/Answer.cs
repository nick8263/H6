namespace Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string? FreeTextAnswer { get; set; }        
        public List<AnswerGroup>? AnswerGroups { get; set; }
        public string? SelectedAnswer { get; set; }
    }
}
