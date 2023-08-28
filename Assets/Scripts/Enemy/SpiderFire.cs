using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFire : MonoBehaviour
{
    private Spider _spider;
    private void Start()
    {
        _spider = GetComponentInParent<Spider>();   
    }
    public void Fire()
    {
        _spider.Attack();
    }
}
