using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Option
    {
        public int Id { get; set; }
        public string PossibleOption { get; set; }
       
        public List<Question>? Questions { get; set; }
    }
}
