
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Entity.Npc
{
    public abstract class MovementBehaviour
    {
        protected abstract Rigidbody2D Rb { get; }
        protected abstract float MovementSpeed { get; }

        protected bool HasArrived(Vector2 targetPos)
        {
            if ((Rb.position == targetPos)) return true;
            return false;

        }

        protected void GoToPos(Vector3 targetPos)
        {
            Rb.position = Vector3.MoveTowards(Rb.position, targetPos, MovementSpeed * Time.deltaTime);
        }
        protected Vector2 GetNewWanderTarget(Vector2 centerPoint, float wanderRadius)
        {
            return new Vector2(
            Random.Range(centerPoint.x - wanderRadius, centerPoint.x + wanderRadius),
            Random.Range(centerPoint.y - wanderRadius, centerPoint.y + wanderRadius)
            );
        }

        protected bool CheckEntityTargetInAggro(Vector2 OriginPos, Vector2 targetPos, float aggroRange)
        {
            if (targetPos.x > OriginPos.x - aggroRange && targetPos.x < OriginPos.x + aggroRange)
            {
                if (targetPos.y > OriginPos.y - aggroRange && targetPos.y < OriginPos.y + aggroRange)
                {
                    OnTargetEntityInAggro();
                    return true;
                }
            }
            return false;

        }
        
        public abstract void Update();
        protected abstract void OnTargetEntityInAggro();
        protected abstract void Wander();
        protected abstract void Idle();

    }
}
