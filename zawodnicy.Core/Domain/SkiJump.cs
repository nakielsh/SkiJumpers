using System;
namespace Zawodnicy.Core.Domain
{
    public class SkiJump
    {
        public int Id { get; set; }
        public Town Town { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public int K { get; set; }
        public int Sedz { get; set; }

        public SkiJump()
        {
        }
    }
}
