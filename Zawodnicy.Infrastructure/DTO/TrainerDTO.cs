using System;
namespace Zawodnicy.Infrastructure.DTO
{
    public class TrainerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public TrainerDTO()
        {
        }
    }
}
