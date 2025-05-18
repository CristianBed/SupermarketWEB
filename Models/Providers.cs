namespace SuperMarketWEB.Models
{
    public class Providers
    {
        public int Id { get; set; } // será la llave primaria
        public string? Name { get; set; }
        public int? Number { get; set; }
        public string? Observation { get; set; }
    }
}
