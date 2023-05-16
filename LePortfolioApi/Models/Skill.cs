using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LePortfolioApi.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string Label { get; set; } = default!;
        public string Icon { get; set; } = default!;

        [JsonIgnore]
        public virtual ProjectSkill ProjectSkill { get; set; } = default!;

    }
}
