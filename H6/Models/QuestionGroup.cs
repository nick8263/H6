namespace Models
{
    public class QuestionGroup
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public Area Area { get; set; }
        public List<Question> Questions { get; set; }

    }
}
