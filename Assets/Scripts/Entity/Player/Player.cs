using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts.Entity;
using Assets.Scripts.Entity.Player;
using Assets.Scripts.Entity.Player.Abilities;
using Assembly_CSharp;

public class Player : MonoBehaviour
{
    private PlayerMovementHandler _movementHandler;
    private AbilityHandler _abilityHandler;
    public int Direction { get; private set; }
 
    // Start is called before the first frame update
    void Start()
    {
       
        _movementHandler = new PlayerMovementHandler(gameObject);
        _abilityHandler = new AbilityHandler();
        _abilityHandler.AddAbility(new DodgeAbility(_movementHandler, KeyCode.Space));
        _abilityHandler.AddAbility(new SpinAbility(KeyCode.E));
        _abilityHandler.AddAbility(new FireballAbility(transform, KeyCode.Q));
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector2 moveVec = _movementHandler.Update();
        _abilityHandler.Update();
        SetDir(moveVec);
    }

    void SetDir(Vector2 dir)
    {
        if (dir.x > 0)
        {
            Direction = 2; // right
            return;
        }
        if (dir.x < 0)
        {
            Direction = 4; //left
            return;
        }
        if(dir.y > 0)
        {
            Direction = 1; //up
            return;
        }
        if (dir.y < 0)
        {
            Direction = 3; // down
            return;
        }
        Direction = 0;
        
        
    }
}
