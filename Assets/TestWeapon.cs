using Assets.Scripts.Entity.Npc;

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
        _stats = new ItemStats(2,1,1,0.2f, 0.5f);
        _attackTimer = _stats.AttackCooldown; // so first attack doesn't have a delay
        _anim = GetComponent<Animator>();
        _anim.speed = 1/_stats.AttackDuration;

    }

    // Update is called once per frame
    void Update()
    {
        if (_parentSlot.PrimaryAttackDisabled()) return;
        if (_hitbox == null) return;
        _attackTimer += Time.deltaTime;

        //attack cooldown = duration + cooldown
        if (_attackTimer >= _stats.AttackCooldown)
        {
            _attackTimer = _stats.AttackCooldown;
            if (Input.GetMouseButton(0))
            {
                _attackTimer = 0;
                _parentSlot.RotateToMouse();
                _hitbox.enabled = true;
                _anim.SetTrigger("Attack");
            }
        }
        //if attack is over reset position and rotation
        else if (_attackTimer >= _stats.AttackDuration) 
        {
            _hitbox.enabled = false;
            _parentSlot.ResetPosition();
        }
        
    }


    /// <summary>
    /// Gets called when collision occures
    /// </summary>
    /// <param name="collision">The collider that collided with object</param>
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
