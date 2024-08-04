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

        private const float SPINS_PER_SECOND = 3.0f;
        protected override float CooldownPeriod { get { return 4.0f; } }
        protected override float Duration { get { return 3.5f; } }
        public override KeyCode KeyBind { get { return _key; } }

        private WeaponSlot _weaponSlot;
        private Collider2D _hitbox;

        public SpinAbility(KeyCode key)
        {
            _key = key;
            GameObject weaponSlotObject = GameObject.Find("WeaponSlot");
            _weaponSlot = weaponSlotObject.GetComponent<WeaponSlot>();
            _hitbox = _weaponSlot.GetHitboxOfWeapon();
            SetGuiIcon("UiSprites/SpinAttackIcon");
        }

        protected override void OnAbilityUpdate()
        {
            if(_active)
            {
           
                _weaponSlot.transform.RotateAround(_weaponSlot.GetParentObject().transform.position,Vector3.forward, SPINS_PER_SECOND * Time.deltaTime * 360);
            }
        }

        protected override void AbilityEffect()
        {
            _active = true;
           _hitbox.enabled = true;
            _weaponSlot.DisablePrimaryAttack();
        }

        protected override void NotifyAbilityFinish()
        {
            _active = false;
            _hitbox.enabled = false;
            _weaponSlot.EnablePrimaryAttack();
            _weaponSlot.ResetPosition();
        }
    }
}
