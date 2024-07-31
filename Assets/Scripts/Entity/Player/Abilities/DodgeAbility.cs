using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

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
        
        private RectTransform _cooldownIndicator;
        private float _indicatorIncrement;

        public DodgeAbility(PlayerMovementHandler handler, KeyCode keybind)
        {
            _key = keybind;
            _movementHandler = handler;
            GameObject uiIcon = Resources.Load<GameObject>("Prefabs/AbilityUI/AbilityIcon");
            uiIcon = GameObject.Instantiate(uiIcon, GameObject.Find("Canvas").transform);
            _cooldownIndicator = uiIcon.transform.Find("CooldownIndicator").GetComponent<RectTransform>();
            _cooldownIndicator.eulerAngles = new Vector3(90, 0, 0);
            _indicatorIncrement =  90.0f / (CooldownPeriod + Duration) ;
        }

        public override void Update()
        {
           UpdateCooldownIndicator();
            UpdateAbilityFinishNotifier();

        }

        protected override void AbilityEffect()
        {
            _cooldownIndicator.eulerAngles = new Vector3(0,0,0);
            _movementHandler.SetMovementSpeed(DODGE_SPEED);
        }

        protected override void NotifyAbilityFinish()
        {
            _movementHandler.ResetSpeed();
        }

        private void UpdateCooldownIndicator()
        {
            if( GetCooldownTime() != 0) _cooldownIndicator.Rotate(new Vector3(_indicatorIncrement * Time.deltaTime, 0, 0));
            else _cooldownIndicator.eulerAngles = new Vector3(90, 0, 0); 
        }
    }
}
