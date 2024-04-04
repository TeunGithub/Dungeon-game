using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;

namespace Assets.Scripts.Entity.Player
{
    public abstract class Ability
    {
        protected abstract float CooldownPeriod { get;}
        protected abstract float Duration { get; }
        public abstract KeyCode KeyBind { get; }
        private float _nextUse;
        private bool isNotified;

        public Ability() 
        {
            _nextUse = 0;
        }
        
        /// <summary>
        /// Checks if ability has finished, if so; updates NotifyAbilityFinish. Use incase Ability needs to reset at end of duration
        /// </summary>
        protected void UpdateAbilityFinishNotifier()
        {
            if (Time.time > _nextUse - CooldownPeriod)
            {
                if (!isNotified)
                {
                    NotifyAbilityFinish();
                    isNotified = true;
                }
            }
        }

        /// <summary>
        /// Checks if duration and cooldown of ability has ended
        /// </summary>
        /// <returns>True if ability can be activated</returns>
        protected bool IsAvailable()
        {
            return Time.time > _nextUse;
        }

        /// <summary>
        /// activates the ability, also resets the AbilityFinishNotifier
        /// </summary>
        public void Use()
        {
            if(IsAvailable())
            {
                _nextUse = Time.time + CooldownPeriod + Duration;
                AbilityEffect();
                isNotified = false;
               
                Debug.Log("used an ability");
            }

        }
        /// <summary>
        /// Updates the ability
        /// </summary>
        public abstract void Update();



        /// <summary>
        /// The effect of the ability
        /// </summary>
        protected abstract void AbilityEffect();

        /// <summary>
        /// Updates when ability has ended
        /// </summary>
        protected abstract void NotifyAbilityFinish();

    }

}
