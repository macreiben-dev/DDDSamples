using System;

namespace DDD.Demos.ValueObjects.Lasergame
{
    public struct Ammunition
    {
        private const int Empty = 0;
        private const int ReloadIncrement = 1;
        private const int MaximumLoadout = 10;
        private const int MinimumLoadout = 0;
        private readonly int _loadout;

        public Ammunition(int initialLoadout)
        {
            if(initialLoadout > MaximumLoadout)
            {
                throw new Exception($"Maximum loadout is {MaximumLoadout}.");
            }

            _loadout = initialLoadout;
        }

        public int Loadout => _loadout;

        public Ammunition Reload()
        {
            if(_loadout == MaximumLoadout)
            {
                return new Ammunition(MaximumLoadout);
            }

            return new Ammunition(_loadout + ReloadIncrement);
        }

        public bool IsEmpty()
        {
            return _loadout == Empty;
        }

        public Ammunition Decrease()
        {
            if(_loadout == MinimumLoadout)
            {
                return new Ammunition(MinimumLoadout);
            }

            return new Ammunition(_loadout - 1);
        }
    }
}