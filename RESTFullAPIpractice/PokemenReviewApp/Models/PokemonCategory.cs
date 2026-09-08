namespace PokemenReviewApp.Models
{
    public class PokemonCategory
    {
       

        public int PokemonId { get ; set ; }
        public int CatgeoryId { get ; set ; }
        public Pokemon Pokemon { get; set; }
        public Category Category { get; set; }
    }
}
