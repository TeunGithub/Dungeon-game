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
 
    // Start is called before the first frame update
    void Start()
    {
       
        _movementHandler = new PlayerMovementHandler(gameObject);
        _abilityHandler = new AbilityHandler();
        _abilityHandler.AddAbility(new DodgeAbility(_movementHandler, KeyCode.Space));
    }

    // Update is called once per frame
    void Update()
    {
       
        _movementHandler.Update();
        _abilityHandler.Update();
    }
}
