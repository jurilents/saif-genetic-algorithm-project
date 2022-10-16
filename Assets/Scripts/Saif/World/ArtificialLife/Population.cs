using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Saif.World.ArtificialLife
{
    /// <summary>
    /// A collection of wrappers for all bots on the farm in any state of life
    /// </summary>
    public class Population : IEnumerable<BioUnit>
    {
        private readonly Dictionary<uint, BioUnit> _aliveBots;
        private readonly Queue<BioUnit> _reservePool;
        private readonly Queue<(BioUnit, BioUnit[])> _birthNote;
        private readonly Queue<BioUnit> _deathNote;

        /// <summary>
        /// Count of alive boys
        /// </summary>
        public int Count => _aliveBots.Count;

        // TODO: remove it
        public int ReserveCount => _reservePool.Count;


        /// <summary>
        /// First initialisation constructor with pre-building of all bots
        /// </summary>
        public Population()
        {
            _aliveBots = new Dictionary<uint, BioUnit>();
            _reservePool = new Queue<BioUnit>();
            _birthNote = new Queue<(BioUnit, BioUnit[])>();
            _deathNote = new Queue<BioUnit>();
        }

        public IEnumerator<BioUnit> GetEnumerator() => _aliveBots.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        /// <summary>
        /// Kill and give birth to all previously marked bots
        /// </summary>
        public void ApplyChanges()
        {
            foreach (var bot in _deathNote.Where(bot => _aliveBots.ContainsKey(bot.Id)))
            {
                bot.Death();
                _aliveBots.Remove(bot.Id);
                _reservePool.Enqueue(bot);
            }

            _deathNote.Clear();

            foreach (var (bot, parents) in _birthNote)
            {
                if (bot.Birth())
                    _aliveBots.Add(bot.Id, bot);
                else _reservePool.Enqueue(bot);
            }

            _birthNote.Clear();

            // Debug.Log("POOL: " + _reservePool.Count);
        }


        public void InitBotsPool(int limit)
        {
            if (limit < 1) throw new ArgumentOutOfRangeException();

            // for (int i = 0; i < limit; i++)
            //     _reservePool.Enqueue(new Bot());
        }


        public void Spawn<TGenome>(ushort count = 1) where TGenome : IGenome
        {
            // GlobalSettings.DefaultGenes = typeof(TGenome);

            for (int i = 0; i < count; i++)
            {
                var instance = _reservePool.Dequeue();
                // var instance = new Bot();
                _birthNote.Enqueue((instance, null));
            }

            ApplyChanges();
        }


        /// <summary>
        /// Mark for further creation
        /// </summary>
        /// <param name="parents">Parent bot(s) (at least one)</param>
        public void BirthChildFor([NotNull] params BioUnit[] parents)
        {
            if (parents.Length <= 0)
                throw new ArgumentException("The child must have at least one parent");

            if (_reservePool.Count > 0)
            {
                var instance = _reservePool.Dequeue();
                // var instance = new Bot();
                _birthNote.Enqueue((instance, parents));
            }
            else Debug.LogWarning("Population reserve pool is empty!");
        }


        /// <summary>
        /// Mark for further destruction
        /// </summary>
        /// <param name="bot"></param>
        public void Kill([NotNull] BioUnit bot)
        {
            _deathNote.Enqueue(bot);
        }
    }
}