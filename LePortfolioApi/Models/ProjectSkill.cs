using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LePortfolioApi.Models
{
    public class ProjectSkill
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int SkillId { get; set; }

       
        [JsonIgnore]
        public virtual Project Project { get; set; } = default!;

        
        [JsonIgnore]
        [ForeignKey("SkillId")]
        public virtual Skill Skill { get; set; } = default!;
    }
}
