using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private static FinishTrigger _instance;
    public static FinishTrigger Instance { get { return _instance; } }
    public bool _finished = false;
    private void Awake()
    {
        _instance = this;
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(GameManager.Instance._hasKey)
            {
                UIManager.Instance.Congrats.SetActive(true);
                _finished = true;
            }
            else
            {
                UIManager.Instance.YouNeedKey.SetActive(true);
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
             UIManager.Instance.Congrats.SetActive(false);
             UIManager.Instance.YouNeedKey.SetActive(false);
            

        }
    }
}
