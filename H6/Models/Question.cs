using System.Formats.Tar;
using System.Text.Json.Serialization;

namespace Models
{
    public class Question
    {
        public int Id { get; set; }
        public string PossibleQuestion { get; set; }

        [JsonIgnore]
        public List<QuestionGroup>? QuestionGroups { get; set; }
        public bool IsMultiple { get; set; }
        public List<Option>? Options { get; set; }
    }
}
