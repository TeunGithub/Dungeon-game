using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Assets.Scripts.Entity.Player.Abilities
{
    internal class DodgeAbility : Ability
    {
        private KeyCode _key;
        private PlayerMovementHandler _movementHandler;
        private const float DODGE_SPEED = 50f;
        protected override float CooldownPeriod { get { return 1f; } }
        protected override float Duration { get { return 0.1f; } }
        public override KeyCode KeyBind { get { return _key; } }
        

        public DodgeAbility(PlayerMovementHandler handler, KeyCode keybind)
        {
            
            _key = keybind;
            _movementHandler = handler;
            SetGuiIcon("UiSprites/DodgeIcon");
        }

        protected override void OnAbilityUpdate()
        {

        }

        protected override void AbilityEffect()
        {
            _movementHandler.SetMovementSpeed(DODGE_SPEED);
        }

        protected override void NotifyAbilityFinish()
        {
            _movementHandler.ResetSpeed();
        }
    }
}
