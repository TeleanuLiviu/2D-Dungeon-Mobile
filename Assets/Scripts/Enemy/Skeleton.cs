using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int health { get; set; }

    public void Damage(int Damage)
    {
        if (!_death)
        {
            _anim.SetTrigger("Hit");
            Debug.Log(health);
            health -= Damage;
            if (health < 1)
            {
                _anim.SetTrigger("Death");
                _death = true;
                SpawnCoins();
            }
        }
    }

    public override void Start()
    {
        base.Start();
        health = base.health;
    }
    public override void Update()
    {
        base.Update();
    }

}
