using System;
namespace Zawodnicy.Infrastructure.DTO
{
    public class SkiJumperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        public SkiJumperDTO()
        {
            
        }

    }
}
