
namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public Book(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

    }
}
