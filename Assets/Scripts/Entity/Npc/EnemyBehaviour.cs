using Assets.Scripts;
using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class EnemyBehaviour : MonoBehaviour
{

    public Vector2 SpawnPosition { get; set; }
    private float _wanderRadius = 2f;
    private float _aggroRange = 4f;


    private Rigidbody2D _rb;
    private NpcMovementHandler _movementHandler;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Rigidbody2D _targetEntity = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _movementHandler = new NpcMovementHandler(_rb, SpawnPosition, _wanderRadius, _aggroRange, _targetEntity);
    }

    void Update()
    {
        if (_movementHandler == null) { return; }
        _movementHandler.Update();
       
    }
  

 


 

   
}
