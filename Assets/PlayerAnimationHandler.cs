using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{
    private Animator _anim;
    private Player _player;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        _anim.SetInteger("walkDirection", _player.Direction);
    }
}
