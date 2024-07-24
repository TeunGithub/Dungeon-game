using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemStats
{
    public float DamageValue { get; set; }
    public float KnockbackValue { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackDuration { get; set; }
    public float AttackCooldown { get; private set; }

    public ItemStats(float damage, float knockback, float attackSpeed, float attackDuration, float attackCooldown) 
    {
        DamageValue = damage;
        KnockbackValue = knockback;
        AttackSpeed = attackSpeed;
        AttackCooldown = attackCooldown + attackDuration;
        AttackDuration = attackDuration;
    }

}

