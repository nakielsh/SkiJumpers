using System;
using System.Threading.Tasks;

namespace Zawodnicy.Core.Domain
{
    public class SkiJumper
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ForeName { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Trainer Trainer { get; set; }

        public SkiJumper()
        {
        }

        public static explicit operator Task<object>(SkiJumper v)
        {
            throw new NotImplementedException();
        }
    }
}
