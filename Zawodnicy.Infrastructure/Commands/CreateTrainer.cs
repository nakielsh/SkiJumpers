using System;
namespace Zawodnicy.Infrastructure.Commands
{
    public class CreateTrainer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateTrainer()
        {
        }
    }
}
