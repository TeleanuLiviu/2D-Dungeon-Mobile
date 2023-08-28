using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canAttack = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        IDamageable hit = collision.GetComponent<IDamageable>();

        if(hit!=null && _canAttack)
        {
            hit.Damage(1);
            _canAttack = false;
            StartCoroutine(WaitforDamage());
        }
    }

    private IEnumerator WaitforDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canAttack = true;
    }
}
