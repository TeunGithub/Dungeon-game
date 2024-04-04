using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Entity.Npc
{
    internal class NpcMovementHandler
    {
        private Rigidbody2D _rb;
        private float _movementSpeed = 3f;
        private const float MAX_DEVIATION = 1f;
        private bool _reachedX;
        private bool _reachedY;
        public NpcMovementHandler(Rigidbody2D rigidbody)
        {
            _rb = rigidbody;
        }
        
        public bool HasArrived(Vector2 targetPos)
        {
            

            return _reachedX && _reachedY;
                
        }

        private float GetDistanceX(Vector2 targetPos)
        {
            if(targetPos.x < 0)
            {
                return (targetPos.x - _rb.position.x) * -1;
            }
            return targetPos.x - _rb.position.x;
        }

        private float GetDistanceY(Vector2 targetPos)
        {
            if (targetPos.y < 0)
            {
                return (targetPos.y - _rb.position.y) * -1;
            }
            return targetPos.y - _rb.position.y;
        }

        public void GoToPos(Vector2 newPos)
        {
            Vector2 currentPos = _rb.position;
            _reachedX = GetDistanceX(newPos) < MAX_DEVIATION;
            _reachedY = GetDistanceY(newPos) < MAX_DEVIATION;

            _rb.position = Vector3.MoveTowards(currentPos, newPos, _movementSpeed * Time.deltaTime);
        }
    }
}
