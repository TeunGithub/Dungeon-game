using Assets.Scripts.Entity.Npc;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public class TestWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider2D _hitbox;
    private float _attackTimer;
    private ItemStats _stats;
    private Animator _anim;
    private WeaponSlot _parentSlot;
    void Start()
    {
        _parentSlot = gameObject.transform.parent.gameObject.GetComponent<WeaponSlot>();
        _hitbox = GetComponent<Collider2D>();
        _stats = new ItemStats(2,1,1,0.2f, 2);
        _attackTimer = _stats.AttackCooldown; // so first attack doesn't have a delay
        _anim = GetComponent<Animator>();
        _anim.speed = 1/_stats.AttackDuration;

    }

    // Update is called once per frame
    void Update()
    {
        if (_hitbox == null) return;
        _attackTimer += Time.deltaTime;
        if(_attackTimer > _stats.AttackCooldown - ((_stats.AttackSpeed -1)/100) && Input.GetMouseButtonDown(0))
        {
            _parentSlot.SetAttackPosition();
            _attackTimer = 0;
            _hitbox.enabled = true;
            _anim.SetTrigger("Attack");

        }
        if (_attackTimer > _stats.AttackDuration )
        {
            _hitbox.enabled = false;
            transform.position = _parentSlot.gameObject.transform.position;
            transform.rotation = _parentSlot.GetRotation();
            _parentSlot.ResetPosition();
           

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collidingObject = collision.gameObject; 
        if(collidingObject.tag == "Enemy")
        {
            IHostileEntity enemy = collidingObject.GetComponent<IHostileEntity>();
            if(enemy != null)
            {
                enemy.OnHit(_stats);
            }
        }
    }
}
