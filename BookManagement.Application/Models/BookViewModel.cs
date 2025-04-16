using BookManagement.Core.Entities;

namespace BookManagement.Application.Models
{
    public class BookViewModel
    {
        public BookViewModel(int id, string title, string author, string iSBN, int publicationYear)
        {
            Id = id;
            Title = title;
            Author = author;
            ISBN = iSBN;
            PublicationYear = publicationYear;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; private set; }

        public static BookViewModel FromEntity(Book entity)
            => new (entity.Id, entity.Title, entity.Author, entity.ISBN, entity.PublicationYear); 
    }
}
