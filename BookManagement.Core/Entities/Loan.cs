namespace BookManagement.Core.Entities
{
    public class Loan
    {
        public Loan(int id, int idUser, int idBook)
        {
            Id = id;
            IdUser = idUser;
            IdBook = idBook;
            LoanDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public int IdUser { get; private set; }
        public User User { get; private set; }
        public int IdBook { get; private set; }
        public Book Book { get; private set; }
        public DateTime LoanDate { get; private set; }

        public DateTime? ReturnDate { get; private set; }

        public void RegisterReturn(DateTime returnDate)
        {
            ReturnDate = returnDate;
        }
    }
}
