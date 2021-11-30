using System;
namespace Zawodnicy.Infrastructure.Commands
{
    public class UpdateSkiJumper
    {
        public UpdateSkiJumper()
        {
        }

        public int Height { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public int Weight { get; set; }
    }
}
