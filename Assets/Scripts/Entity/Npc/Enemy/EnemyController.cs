using Assets.Scripts;
using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public Vector2 SpawnPosition { get; set; }
    private float _wanderRadius = 2f;
    private float _aggroRange = 4f;

    public EntityDied EntityGotKilled { get; set; }
    private Rigidbody2D _rb;
    private MovementBehaviour _movementBehaviour;
    


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Rigidbody2D _targetEntity = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _movementBehaviour = new EnemyMovementBehaviour(_rb, SpawnPosition, _wanderRadius, _aggroRange, _targetEntity);
    }

    void Update()
    {
        if (_movementBehaviour == null) { return; }
        _movementBehaviour.Update();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject exp = Resources.Load<GameObject>("Prefabs/Entities/Exp");
            int expSpawnCount = Random.Range(1, 4);
            for (int i = 0; i < expSpawnCount; i++)
            {
                float spawnPosX = _rb.position.x + Random.Range(-0.5f, 0.5f);
                float spawnPosY = _rb.position.y + Random.Range(-0.5f, 0.5f);
                Instantiate(exp, new Vector3(spawnPosX, spawnPosY), Quaternion.identity);
            }
            EntityGotKilled();
            Destroy(this.gameObject);

        }
    }






}
