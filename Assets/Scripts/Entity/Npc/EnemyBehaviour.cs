using Assets.Scripts;
using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour, ISubscriber
{

    public Vector2 SpawnPosition { get; set; }
    private float _wanderRadius = 4f;
    private Rigidbody2D _rb;
    private NpcMovementHandler _movementHandler;
    private Vector2 _target;

    private Rigidbody2D _player;
    private float _aggroRange = 10f;

    private const float SEARCH_TARGET_RATE = 5f;
    private float _nextUpdate;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _movementHandler = new NpcMovementHandler(_rb);
        _target = GetNewWanderTarget(SpawnPosition, _wanderRadius);
        World world = GameObject.Find("World").GetComponent<World>();
        world.Subscribe(this);
    }

    public void Notify()
    {
        if (_movementHandler == null) { return; }

        if (IsPlayerInAgro())
        {
            _target = _player.position;
        }
        else
        {
            if (Time.time > _nextUpdate)
            {
                if (_movementHandler.HasArrived(_target))
                {

                    _target = GetNewWanderTarget(SpawnPosition, _wanderRadius);
                }
                _nextUpdate = Time.time + SEARCH_TARGET_RATE;
            }
        }

        _movementHandler.GoToPos(_target);
    }

    private bool IsPlayerInAgro()
    {
        Vector2 _playerPos = _player.position;
        if(_playerPos.x > SpawnPosition.x - _aggroRange && _playerPos.x < SpawnPosition.x + _aggroRange)
        {
            if(_playerPos.y > SpawnPosition.y - _aggroRange && _playerPos.y < SpawnPosition.y + _aggroRange)
            {
                Debug.Log("Player is in agro range");
                return true;
            }
        }
        return false;
    }


    private Vector2 GetNewWanderTarget(Vector2 centerPoint,float wanderRadius)
    {
        return new Vector2(
        Random.Range(centerPoint.x - wanderRadius, centerPoint.x + wanderRadius),
        Random.Range(centerPoint.y - wanderRadius, centerPoint.y + wanderRadius)
        );
    }

   
}
