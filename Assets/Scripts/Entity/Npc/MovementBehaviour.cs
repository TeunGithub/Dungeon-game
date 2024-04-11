
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Assets.Scripts.Entity.Npc
{
    public abstract class MovementBehaviour
    {
        protected abstract Rigidbody2D Rb { get; }
        protected abstract float MovementSpeed { get; }

        private bool _reachedTargetEntity = false;

        /// <summary>
        /// checks if rigidbody has arrived at te target location
        /// </summary>
        /// <param name="targetPos">the target location</param>
        /// <returns></returns>
        protected bool HasArrived(Vector2 targetPos)
        {
            if ((Rb.position == targetPos)) return true;
            return false;

        }
        /// <summary>
        /// Moves the attached Rigidbody to the target location
        /// </summary>
        /// <param name="targetPos">the location where you want to move to</param>
        protected void GoToPos(Vector3 targetPos)
        {
            if (_reachedTargetEntity) return;
            Rb.position = Vector3.MoveTowards(Rb.position, targetPos, MovementSpeed * Time.deltaTime);

        }

        /// <summary>
        /// Gets a random target location inside a given wander radius
        /// </summary>
        /// <param name="centerPoint">the middle point of the area</param>
        /// <param name="wanderRadius">the radius that a position can be selected in</param>
        /// <returns></returns>
        protected Vector2 GetNewWanderTarget(Vector2 centerPoint, float wanderRadius)
        {
            return new Vector2(
            Random.Range(centerPoint.x - wanderRadius, centerPoint.x + wanderRadius),
            Random.Range(centerPoint.y - wanderRadius, centerPoint.y + wanderRadius)
            );
        }

        /// <summary>
        /// Checks if the target is inside a given radius. Also calls OnTargetEntityInAggro if target is whithin aggro range
        /// </summary>
        /// <param name="OriginPos">the middle of the area</param>
        /// <param name="targetPos">the position of the target</param>
        /// <param name="aggroRange">the range at wich te enity gets aggroed</param>
        /// <returns></returns>
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

        public void SetReachedTargetEntity(bool value)
        {
            _reachedTargetEntity = value;
        }

        public abstract void Update();
        protected abstract void OnTargetEntityInAggro();
        protected abstract void Wander();
        protected abstract void Idle();

    }
}
