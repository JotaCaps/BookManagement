namespace BookManagement.Core.Entities
{
    public class Book
    {
        public Book(int id, string title, string author, string? iSBN, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
            Loans = [];
        }

        public int Id { get; private set; }
        public string Title{ get; private set; }
        public string Author{ get; private set; }
        public string? ISBN { get; private set; }
        public int PublicationYear { get; private set; }

        public List<Loan> Loans { get; private set; }
    }
}
