using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LePortfolioApi.Models
{
    public class Link
    {
        public int Id { get; set; }
        public string Value { get; set; } = default!;

        public int ProjectId { get; set; }

        public Project Project { get; set; } = default!;
    }
}
