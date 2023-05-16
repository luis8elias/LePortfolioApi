using System.Text.Json.Serialization;

namespace LePortfolioApi.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Url { get; set; } = default!;

        public int ProjectId { get; set; }


        [JsonIgnore]
        public virtual Project Project { get; set; } = default!;


    }
}