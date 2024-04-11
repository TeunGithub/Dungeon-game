
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Entity.Npc
{
    
    internal class EnemyMovementBehaviour : MovementBehaviour
    {
        private Vector2 _spawnPosition;
        private Rigidbody2D _rb;

        private const float CHECK_ARRIVED_RATE = 5f;
        private float _nextWanderSearch;
        private float _wanderRadius;
        private Vector2 _moveTargetPos;
        
        private Rigidbody2D _entityTarget;
        private float _aggroRange;
        protected override Rigidbody2D Rb { get { return _rb; } }
        protected override float MovementSpeed { get { return 3f; } }

        public EnemyMovementBehaviour(Rigidbody2D rb, Vector2 spawnPosition, float wanderRadius, float aggroRange, Rigidbody2D target)
        {
            _rb = rb;
            _entityTarget = target;
            _aggroRange = aggroRange;
            _wanderRadius = wanderRadius;
            _spawnPosition = spawnPosition;
            _moveTargetPos = GetNewWanderTarget(spawnPosition,wanderRadius);
        }

        public override void Update()
        {
            //GoToPos(_entityTarget.position);
           if (!CheckEntityTargetInAggro(_spawnPosition, _entityTarget.position, _aggroRange)) Wander();
            
        }


        protected override void OnTargetEntityInAggro()
        {
            GoToPos(_moveTargetPos);
            _moveTargetPos = _entityTarget.position;
           

        }

        protected override void Wander()
        {
          
            if (Time.time > _nextWanderSearch)
            {
                if(HasArrived(_moveTargetPos)) _moveTargetPos = GetNewWanderTarget(_spawnPosition, _wanderRadius);
                _nextWanderSearch = Time.time + CHECK_ARRIVED_RATE;
            }

            GoToPos(_moveTargetPos);

        }

        protected override void Idle()
        {
        
        }

       
    }
}
