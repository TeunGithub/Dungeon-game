using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour
{
    private Vector2 _moveDirection;
    private ItemStats _stats;
    private const float MOVE_SPEED = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        _stats = new ItemStats(3.0f,4.0f,0.0f,0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveDirection == Vector2.zero) return;
        transform.position += new Vector3(_moveDirection.x, _moveDirection.y) * MOVE_SPEED * Time.deltaTime;
    }
    public void SetMoveDirection(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingObject = collision.gameObject;
        if (collidingObject.tag == "Enemy")
        {
            IHostileEntity enemy = collidingObject.GetComponent<IHostileEntity>();
            if (enemy != null)
            {
                enemy.OnHit(_stats);
            }
        }
        Destroy(gameObject);
    }
}
