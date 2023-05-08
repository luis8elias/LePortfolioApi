namespace LePortfolioApi.Dtos
{
    public class ValidationError
    {
        public string PropertyName { get; set; } = default!;

        public IEnumerable<string> Errors { get; set; } = default!;
    }
}
