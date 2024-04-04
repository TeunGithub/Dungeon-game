using Assets.Scripts.Entity.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assembly_CSharp
{
    internal class AbilityHandler
    {
        private List<Ability> abilities;
        public AbilityHandler() 
        {
            abilities = new List<Ability>();
        }

        /// <summary>
        /// Adds an ability to the ability handler
        /// </summary>
        /// <param name="ability"></param>
        public void AddAbility(Ability ability)
        {
            abilities.Add(ability);
        }

        /// <summary>
        /// Removes an ability from te ability handler
        /// </summary>
        /// <param name="ability"></param>
        public void RemoveAbility(Ability ability)
        {
            abilities.Remove(ability);
        }

        /// <summary>
        /// Updates the abilities in the ability handler
        /// </summary>
        public void Update()
        {
            foreach (Ability ability in abilities)
            { 
                if (Input.GetKeyDown(ability.KeyBind))
                {
                    ability.Use();
                }
                ability.Update();
            }
        }
    }
}
