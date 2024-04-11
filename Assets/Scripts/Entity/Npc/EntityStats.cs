﻿using Assets.Scripts.Entity;
using Assets.Scripts.Entity.Npc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EntityStats
{
    private float _maxHealth;
    public float Atk { get; private set; }
    public float Health { get; private set; }
    public float AttackCooldown { get; private set; }


    public EntityStats(float health, float atk, float attackCooldown)
    {
        Atk = atk;
        Health = health;
        _maxHealth = health;
        AttackCooldown = attackCooldown;
    }

    public void ReduceHealth(float damage, IHostileEntity entity)
    {
        Health -= damage;
        if(Health <= 0)
        {
            entity.OnEntityDied();
        }
    }
}
