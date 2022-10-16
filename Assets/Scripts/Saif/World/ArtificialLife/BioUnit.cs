using Saif.World.Core;

namespace Saif.World.ArtificialLife
{
    public abstract class BioUnit : IFarmObject
    {
        private static uint _idIterator = 100;
        public uint Id { get; private set; }
        public bool IsAlive { get; protected set; }
        public int Age { get; protected set; }
        protected IGenome Genome { get; private set; }

        protected abstract void OnBirth();
        protected abstract void OnDeath();

        public bool Birth()
        {
            Id = _idIterator++;
            if (_idIterator == uint.MaxValue)
                _idIterator = 100;
            OnBirth();
            return true;
        }

        public void Death()
        {
            OnDeath();
        }

        public void Step()
        {
            Genome.Next();
        }
    }
}