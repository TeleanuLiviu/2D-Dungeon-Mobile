using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy :MonoBehaviour 
{
    [SerializeField]
    private GameObject DiamondPrefab;
    [SerializeField]
    public int health;
    [SerializeField]
    public int speed;
    [SerializeField]
    public int gems;
    [SerializeField]
    protected Transform PointA, PointB;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _currentTarget;
    protected Animator _anim;
    [SerializeField]
    protected bool _gotHit = false;
    protected Player _player;
    protected bool _death;
    public virtual void Start()
    {
        _death = false;
           _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _currentTarget = PointB.position;
        _anim = GetComponentInChildren<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public virtual void Update()
    {
        if (!_death)
        {
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {

                return;
            }
            if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                _gotHit = true;
            }

            else if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Walk") || _anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                _gotHit = false;
            }


            if (!_gotHit)
            {
                AIMove();
            }

            float distance = Vector3.Distance(transform.position, _player.transform.position);
            Vector3 direction = _player.transform.position - transform.position;
            if (direction.x > 0.5 && _anim.GetBool("Combat") == true)
            {
                _spriteRenderer.flipX = false;
            }

            else if (direction.x < 0.5 && _anim.GetBool("Combat") == true)
            {
                _spriteRenderer.flipX = true;
            }

            if (distance < 1.5f)
            {
                _gotHit = true;
                _anim.SetBool("Combat", true);
            }
            else
            {
                _anim.SetBool("Combat", false);
            }
        }
      
       
    }

    private void AIMove()
    {
        if(transform.position == PointB.position)
        {
            _currentTarget = PointA.position;
            _anim.SetTrigger("Idle");
            _spriteRenderer.flipX = true;
        }
        else if (transform.position == PointA.position)
        {
            _currentTarget = PointB.position;
            _anim.SetTrigger("Idle");
            _spriteRenderer.flipX = false;
        }

        if(transform.position.x-_currentTarget.x >0)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
       


        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);
    }

   public void SpawnCoins()
    {
        for (int i=0;i<gems;i++)
        {
            Instantiate(DiamondPrefab, transform.position + new Vector3(i,0,0), Quaternion.identity);

        }
    }
   
}
