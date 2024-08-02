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
        private const float ICON_OFFSET = 5;
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
            AllignAbilityIcons();
        }

        /// <summary>
        /// Removes an ability from te ability handler
        /// </summary>
        /// <param name="ability"></param>
        public void RemoveAbility(Ability ability)
        {
            abilities.Remove(ability);
            AllignAbilityIcons();
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

        private void AllignAbilityIcons()
        {   
            for (int i = 0; i < abilities.Count; i++)
            {
                Vector2 position = new Vector2(30 + (i * (60 + ICON_OFFSET)),0);
                abilities[i].SetIconPosition(position);
            }

            float offsetToCenter = ((abilities.Count * (60 + ICON_OFFSET)) - ICON_OFFSET) / 2.0f;
            foreach (Ability ability in abilities)
            {
                ability.ShiftIconPosition(new Vector2(-offsetToCenter, 0));
            }
        }
    }
}
