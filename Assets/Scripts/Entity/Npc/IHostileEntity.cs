using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entity.Npc
{
    public interface IHostileEntity
    {
        public Vector2 SpawnPosition { get; set; }
        public EntityDied EntityGotKilled { get; set; }
        public EntityStats Stats { get; }

        void OnEntityDied();
        void OnHit(ItemStats stats);
        void Attack();
    }
}
