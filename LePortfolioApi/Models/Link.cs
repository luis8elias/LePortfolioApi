using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LePortfolioApi.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;

        public int ProjectId { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; } = default!;

    }
}
