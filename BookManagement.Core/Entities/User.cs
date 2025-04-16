namespace BookManagement.Core.Entities
{
    public class User
    {
        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
            Loans = [];
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public List<Loan> Loans { get; private set; }
    }
}
