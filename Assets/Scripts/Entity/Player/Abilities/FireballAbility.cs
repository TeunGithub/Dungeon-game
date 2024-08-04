using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Entity.Player.Abilities
{
    internal class FireballAbility : Ability
    {
        private KeyCode _key;
        public override KeyCode KeyBind {get {return _key;} }

        protected override float CooldownPeriod { get { return 3.0f; }}

        protected override float Duration {get { return 0; } }

        private Transform _parentTransform;
        private GameObject _fireballPrefab;

        public FireballAbility(Transform parentTransform, KeyCode key)
        {
            _parentTransform = parentTransform;
            _key = key;
            _fireballPrefab = Resources.Load<GameObject>("Prefabs/Entities/Fireball");
            base.SetGuiIcon("UiSprites/FireballIcon");
            
            

        }

        protected override void AbilityEffect()
        {
            Vector3 parentPosition = _parentTransform.position;
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 directionVec = GetVectorToMouse(parentPosition, mousePositionInWorld);

            GameObject fireballObject = GameObject.Instantiate(_fireballPrefab, _parentTransform.position, Quaternion.identity);
     
            fireballObject.transform.position = _parentTransform.position + (directionVec * 1.5f);
            fireballObject.transform.Rotate(Vector3.forward, GetAngleToMouse(parentPosition, mousePositionInWorld));
            fireballObject.GetComponent<FireballBehaviour>().SetMoveDirection(directionVec);

        }

        protected override void NotifyAbilityFinish()
        {
            
        }

        protected override void OnAbilityUpdate()
        {
      
        }
        private Vector3 GetVectorToMouse(Vector3 currentPos, Vector3 mousePos)
        {
            return new Vector3(mousePos.x - currentPos.x, mousePos.y - currentPos.y, 0).normalized;
        }

        private float GetAngleToMouse(Vector3 currentPos, Vector3 mousePos)
        {

            return Mathf.Atan2(mousePos.y - currentPos.y, mousePos.x - currentPos.x) * Mathf.Rad2Deg;
        }

    }
}
