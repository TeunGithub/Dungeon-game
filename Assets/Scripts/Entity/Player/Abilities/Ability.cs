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
        internal void UpdateAbilityFinishNotifier()
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
                if(_cooldownIndicator != null) _cooldownIndicator.eulerAngles = new Vector3(0, 0, 0);
                AbilityEffect();
                isNotified = false;
               
                Debug.Log("used an ability");
            }

        }
        /// <summary>
        /// gets the remaining time on cooldown
        /// </summary>
        /// <returns>time of cooldown in seconds</returns>
        public float GetCooldownTime()
        {
            float downTime = _nextUse - Time.time;
            if (downTime <= 0) return 0;
            else return downTime;
        }

        /// <summary>
        /// Updates ability
        /// </summary>
        /// 
        public void Update()
        {
            UpdateCooldownIndicator();
            UpdateAbilityFinishNotifier();
            OnAbilityUpdate();

        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Gui Icon
        private GameObject _uiIcon;
        private RectTransform _cooldownIndicator;
        private float _indicatorIncrement;

        /// <summary>
        /// Sets the Icon of the ability on the GUI.
        /// </summary>
        /// <param name="iconPath">Path from Resource folder to Icon image</param>
        public void SetGuiIcon(string iconPath)
        {
            GameObject uiIconPrefab = Resources.Load<GameObject>("Prefabs/AbilityUI/AbilityIcon");
            _uiIcon = GameObject.Instantiate(uiIconPrefab, GameObject.Find("Canvas/AbilityIcons").transform);

            GameObject abilityIcon = _uiIcon.transform.Find("Icon").gameObject;
            abilityIcon.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>(iconPath);


            _cooldownIndicator = _uiIcon.transform.Find("CooldownIndicator").GetComponent<RectTransform>();
            _cooldownIndicator.eulerAngles = new Vector3(90, 0, 0);
            _indicatorIncrement = 90.0f / (CooldownPeriod + Duration);
        }

        /// <summary>
        /// Updates the indicator for the cooldown duration.
        /// </summary>
        private void UpdateCooldownIndicator()
        {
            if (_cooldownIndicator == null) return;
            if (GetCooldownTime() != 0) _cooldownIndicator.Rotate(new Vector3(_indicatorIncrement * Time.deltaTime, 0, 0));
            else _cooldownIndicator.eulerAngles = new Vector3(90, 0, 0);
        }

        /// <summary>
        /// shifts the position of the icon. The shift is based on the original position of the icon.
        /// </summary>
        /// <param name="position">The amount that the icon needs to be shifted</param>
        public void ShiftIconPosition(Vector2 position)
        {
            RectTransform rTransform = _uiIcon.GetComponent<RectTransform>();
            rTransform.localPosition = new Vector2(rTransform.localPosition.x +position.x, rTransform.localPosition.y + position.y);
           
        }

        /// <summary>
        /// Sets the position of the Icon.
        /// </summary>
        /// <param name="position">The new position of the icon</param>
        public void SetIconPosition(Vector2 position)
        {
            RectTransform rTransform = _uiIcon.GetComponent<RectTransform>();
            rTransform.localPosition = new Vector2(position.x, position.y);

        }



        //-------------------------------------------------------------------------------------------------------------------------------------------------------\\
        //Abstract methodes


        /// <summary>
        /// Updates method for ability effect on updates
        /// </summary>
        /// 
        protected abstract void OnAbilityUpdate();

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
