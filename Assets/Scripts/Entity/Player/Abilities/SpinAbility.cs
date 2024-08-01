using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entity.Player.Abilities
{
    internal class SpinAbility : Ability
    {
        private KeyCode _key;
        private bool _active;
        protected override float CooldownPeriod { get { return 5f; } }
        protected override float Duration { get { return 3.0f; } }
        public override KeyCode KeyBind { get { return _key; } }

        private WeaponSlot _weaponSlot;
        private Collider2D _hitbox;

        public SpinAbility(KeyCode key)
        {
            _key = key;
            
        }

        protected override void OnAbilityUpdate()
        {
            if(_active)
            {

            }
            throw new NotImplementedException();
        }

        protected override void AbilityEffect()
        {
            _active = true;
           
        }

        protected override void NotifyAbilityFinish()
        {
            _active = false;
        
        }
    }
}
