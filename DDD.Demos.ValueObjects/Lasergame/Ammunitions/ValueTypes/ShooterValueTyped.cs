using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.Demos.ValueObjects.Lasergame.Ammunitions.ValueTypes
{
    public sealed class ShooterValueTyped
    {
        public ShooterValueTyped()
        {
        }

        public Ammunition Ammunitions { get; set; }

        public int Id { get; set; }
    }
}
