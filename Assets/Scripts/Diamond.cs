using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            collision.GetComponent<Player>().AddDiamond();
            Destroy(this.gameObject);
        }
    }
}
