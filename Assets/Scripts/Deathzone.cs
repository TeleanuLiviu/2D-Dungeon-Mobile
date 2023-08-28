using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Death");

            Player _player = collision.gameObject.GetComponent<Player>();
            _player.health = 0;
            _player.Damage(0);
        }
    }
}
