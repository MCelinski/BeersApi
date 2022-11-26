namespace BeersApi.Models.Entities
{
    public class Beer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        public int BreweryId { get; set; }

        public decimal Ibu { get; set; }

        public decimal Abv { get; set;}

        public decimal Alc { get; set;}
    }
}
