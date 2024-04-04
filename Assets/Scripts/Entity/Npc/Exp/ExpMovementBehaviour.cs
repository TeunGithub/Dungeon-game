using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Entity.Npc.Exp
{
    internal class ExpMovementBehaviour : MovementBehaviour
    {
        private Rigidbody2D _rb;
        private Rigidbody2D _player;
        private float _aggroRange;
        protected override Rigidbody2D Rb { get { return _rb; } }
        protected override float MovementSpeed { get { return 6f; } }

        public ExpMovementBehaviour(Rigidbody2D rb, Rigidbody2D player, float aggroRange)
        {
            _rb = rb;
            _player = player;
            _aggroRange = aggroRange;
        }

        public override void Update()
        {
            CheckEntityTargetInAggro(Rb.position, _player.position, _aggroRange);
        }

        protected override void Idle()
        {
            throw new NotImplementedException();
        }

        protected override void OnTargetEntityInAggro()
        {
            GoToPos(_player.position);
        }

        protected override void Wander()
        {
            throw new NotImplementedException();
        }
    }
}
