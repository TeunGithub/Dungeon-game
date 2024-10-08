using Assets.Scripts;
using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour, IHostileEntity
{
    private const float MIN_DISTANCE_TARGET = 2f;
    public Vector2 SpawnPosition { get; set; }
    private float _wanderRadius = 2f;
    private float _aggroRange = 4f;
    private float _nextAttack;

    public EntityDied EntityGotKilled { get; set; }
    
    public EntityStats Stats { get { return _stats; } }

    private Rigidbody2D _rb;
    private Rigidbody2D _targetEntity;
    

    private MovementBehaviour _movementBehaviour;
    private EntityStats _stats;
    private HealthbarBehaviour _healthbarBehaviour;
    [SerializeField] private Animator _animator;




    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _targetEntity = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _movementBehaviour = new EnemyMovementBehaviour(_rb, SpawnPosition, _wanderRadius, _aggroRange, _targetEntity);
        _stats = new EntityStats(10, 1, 3);

        _healthbarBehaviour = new HealthbarBehaviour(transform.Find("healthbar/damagebar").gameObject,  transform.Find("healthbar")) ;
    }

    void Update()
    {
        if (distanceXtoPlayer() > 20) return;
        if (distanceYtoPlayer() > 15) return;
        if (_movementBehaviour == null) { return; }

        float distanceToTarget = Vector3.Distance(_rb.position, _targetEntity.position);
        if(distanceToTarget <= MIN_DISTANCE_TARGET){
            _movementBehaviour.SetReachedTargetEntity(true);
            Attack();
        }else{
            _movementBehaviour.SetReachedTargetEntity(false);
        }

       
        _movementBehaviour.Update();
       
    }
    
    /// <summary>
    /// Gets called when entity is hit. Reduces health based on stat values.
    /// </summary>
    /// <param name="itemStats"></param>
    public void OnHit(ItemStats itemStats)
    {
        _rb.velocity = (new Vector2(_targetEntity.position.x - _rb.position.x, _targetEntity.position.y - _rb.position.y).normalized * -(itemStats.KnockbackValue) *10);
        _stats.ReduceHealth(itemStats.DamageValue, this);
        _healthbarBehaviour.UpdateHealth(_stats);
    }

    /// <summary>
    /// Spawns exp entities, calls Entitygotkilled and destroyes self
    /// </summary>
    public void OnEntityDied()
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
        Destroy(gameObject);
    }

    public void Attack()
    {
        if(Time.time > _nextAttack)
        {
            _animator.SetBool("IsAttacking", true);
            float AttackMovementSpeed = 10;
            _rb.velocity = (new Vector2(_targetEntity.position.x - _rb.position.x, _targetEntity.position.y - _rb.position.y).normalized * AttackMovementSpeed);
            _nextAttack = Time.time + _stats.AttackCooldown;
           
        }
        else _animator.SetBool("IsAttacking", false);

    }

    /// <summary>
    /// Gets distance on Y-axis to the player
    /// </summary>
    /// <returns>distance to player on Y-axis</returns>
    private float distanceYtoPlayer()
    {
        float playerY = _targetEntity.position.y;
        float enemyY = transform.position.y;
        return Mathf.Abs(playerY - enemyY);
    }

    /// <summary>
    /// Gets distance on X-axis to the player
    /// </summary>
    /// <returns>distance to player on X-axis</returns>
    private float distanceXtoPlayer()
    {
        byte playerX = (byte)_targetEntity.position.x;
        byte enemyX = (byte)transform.position.x;
        return Mathf.Abs(playerX - enemyX);
    }
}
