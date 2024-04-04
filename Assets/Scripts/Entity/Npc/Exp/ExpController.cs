using Assets.Scripts.Entity.Npc;
using Assets.Scripts.Entity.Npc.Exp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{
    [SerializeField] private float _detectPlayerRange = 4f;
    private MovementBehaviour _movementBehaviour;
    private LogicScript _logicManager;
       
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Rigidbody2D player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        _movementBehaviour = new ExpMovementBehaviour(rb, player, _detectPlayerRange);
        _logicManager = GameObject.FindGameObjectWithTag("UILogic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        _movementBehaviour.Update();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _logicManager.AddScore();
            Destroy(this.gameObject);
        }
    }
}
