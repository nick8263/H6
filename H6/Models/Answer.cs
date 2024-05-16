namespace Models
{
    public class Answer
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public List<AnswerGroup> answerGroups { get; set; }


    }
}
