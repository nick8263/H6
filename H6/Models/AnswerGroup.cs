namespace Models
{
    public class AnswerGroup
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public Area Area { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
