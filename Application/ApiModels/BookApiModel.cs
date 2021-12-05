using System.ComponentModel.DataAnnotations;

namespace Application.ApiModels
{
    public class BookApiModel
    {
        public BookApiModel(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        public int Quantity { get; set; }

    }
}
