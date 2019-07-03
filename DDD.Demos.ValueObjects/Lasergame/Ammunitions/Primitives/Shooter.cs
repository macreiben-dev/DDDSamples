using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Demos.ValueObjects.Lasergame
{
    public sealed class Shooter
    {
        public Shooter()
        {
            Ammunitions = 0;
        }
        public int Ammunitions { get; set; }
        public int Id { get; set; }
    }
}
