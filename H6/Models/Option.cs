using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Option
    {
        public int Id { get; set; }
        public string PossibleOption { get; set; }

        [JsonIgnore]
        public List<Question>? Questions { get; set; }
    }
}
