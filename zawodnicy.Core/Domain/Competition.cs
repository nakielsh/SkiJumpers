using System;
namespace Zawodnicy.Core.Domain
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SkiJump SkiJump { get; set; }
        public DateTime Date { get; set; }

        public Competition()
        {
        }
    }
}
