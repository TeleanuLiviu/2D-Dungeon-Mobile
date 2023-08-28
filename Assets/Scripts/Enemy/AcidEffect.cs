using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidEffect : MonoBehaviour
{
    public Player _player;
 
    Vector3 StartPos;
    Vector3 _playerStartPos;
    public float direction;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5.0f);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        _playerStartPos = new Vector3(_player.transform.position.x, _player.transform.position.y, _player.transform.position.z);
        StartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        direction = _playerStartPos.x - StartPos.x;


    }

    // Update is called once per frame
    void Update()
    {
       

        if (direction<0)
        {
            transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
        }

        else
        {
            transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
        }

      


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        IDamageable hit = collision.GetComponent<IDamageable>();

        if (hit != null)
        {
            hit.Damage(1);
            Destroy(this.gameObject);
           
        }
    }

}
