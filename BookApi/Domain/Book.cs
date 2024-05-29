namespace BookApi.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Gender { get; set; }
        public required string Language { get; set; }

    }
}
