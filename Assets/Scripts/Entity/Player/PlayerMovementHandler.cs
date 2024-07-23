using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Entity
{

    public class PlayerMovementHandler
    {
        [SerializeField] private const float BASE_SPEED = 5f;
        [SerializeField] private float _speed; 
        private Rigidbody2D _rb; 


        public PlayerMovementHandler(GameObject parent)
        {
            _rb  = parent.GetComponent<Rigidbody2D>();
            _speed = BASE_SPEED;
        }


        // Update is called once per frame
        public Vector2 Update()
        {

            Vector2 moveVector = new Vector2();
            if (Input.GetKey(KeyCode.W))
            {
                moveVector.y = 1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveVector.y = -1;
            }
            if(Input.GetKey(KeyCode.D)) 
            {
                moveVector.x = 1; 
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveVector.x = -1;
            }
        
            _rb.velocity = moveVector.normalized * _speed;
            return moveVector;
        }

        /// <summary>
        /// Sets the speed to a new value
        /// </summary>
        /// <param name="newSpeed">the new speed</param>
        public void SetMovementSpeed(float newSpeed)
        {
            _speed = newSpeed;
        }

        /// <summary>
        /// Resets the speed to te base value
        /// </summary>
        public void ResetSpeed()
        {
            if(_speed != BASE_SPEED)
            {
                _speed = BASE_SPEED;
            }
        }
    }
}
