using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int health { get; set; }
    public GameObject Acid;
    private bool isAttacked = false;
    public void Damage(int Damage)
    {

        if (!_death)
        {
            _anim.SetTrigger("Hit");
            Debug.Log(health);
            health -= Damage;
            isAttacked = true;
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
        float distance = Vector3.Distance(transform.position, base._player.transform.position);
        if (distance < 5)
        {
            _gotHit = true;
            _anim.SetBool("Combat", true);
        }
        else
        {
            _anim.SetBool("Combat", false);
        }
    }

    public void Attack()
    {
        if(!isAttacked)
        Instantiate(Acid, this.transform.position, Quaternion.identity);
    }


}
