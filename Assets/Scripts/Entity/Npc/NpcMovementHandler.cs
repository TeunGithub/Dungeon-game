
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Entity.Npc
{
    internal class NpcMovementHandler
    {
        private Vector2 _spawnPosition;
        private Rigidbody2D _rb;
        private float _movementSpeed = 3f;

        private const float SEARCH_WANDER_POS_RATE = 5f;
        private float _nextWanderSearch;
        private float _wanderRadius;
        private Vector2 _targetPos;
        
        private Rigidbody2D _target;
        private float _aggroRange;

      
        

        public NpcMovementHandler(Rigidbody2D ownRb, Vector2 spawnPosition, float wanderRadius, float aggroRange, Rigidbody2D target)
        {
            _rb = ownRb;
            _target = target;
            _aggroRange = aggroRange;
            _wanderRadius = wanderRadius;
            _spawnPosition = spawnPosition;
            _targetPos = GetNewWanderTarget(spawnPosition,wanderRadius);
        }
        
        public bool HasArrived()
        {
            if ((_rb.position == _targetPos)) return true;
            return false;

        }


        public void Update()
        {
            if (IsTargetInAgro())
            {
                _targetPos = _target.position;
            }
            else
            {
                if (Time.time > _nextWanderSearch)
                {
                    if (HasArrived()) _targetPos = GetNewWanderTarget(_spawnPosition, _wanderRadius);
                    _nextWanderSearch = Time.time + SEARCH_WANDER_POS_RATE;
                }
            }

            GoToPos();
        }


        private void GoToPos()
        {
            _rb.position = Vector3.MoveTowards(_rb.position, _targetPos, _movementSpeed * Time.deltaTime);
            
        }

        private Vector2 GetNewWanderTarget(Vector2 centerPoint, float wanderRadius)
        {
            return new Vector2(
            Random.Range(centerPoint.x - wanderRadius, centerPoint.x + wanderRadius),
            Random.Range(centerPoint.y - wanderRadius, centerPoint.y + wanderRadius)
            );
        }

        private bool IsTargetInAgro()
        {
            if(_targetPos == null) return false;
            Vector2 targetPos = _target.position;
            if (targetPos.x > _spawnPosition.x - _aggroRange && targetPos.x < _spawnPosition.x + _aggroRange)
            {
                if (targetPos.y > _spawnPosition.y - _aggroRange && targetPos.y < _spawnPosition.y + _aggroRange)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
