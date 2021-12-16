using System;
namespace Zawodnicy.Infrastructure.Commands
{
    public class CreateSkiJumper
    {
        public CreateSkiJumper()
        {
        }

        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
    }
}
