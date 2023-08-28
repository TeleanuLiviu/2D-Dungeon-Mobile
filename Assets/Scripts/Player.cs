using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Player : MonoBehaviour , IDamageable
{
    private float horizontal;
    private Rigidbody2D _rb;
    private float _jumpHeight = 6.5f;
    [SerializeField]
    private short _speed = 3;
    private Animator _anim;
    private SpriteRenderer _playerSprite, _archSprite;
    private bool attack;
    private Animator _ArcAnim;
    private bool _death;
    [SerializeField]
    public int diamond;
    public int health { get; set; }

    private InputControls _input;

    void Start()
    {
        _input = new InputControls();
        _input.Player.Enable();
        attack = false;
        _death = false;
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        _playerSprite = GetComponentInChildren<SpriteRenderer>();
        _ArcAnim = transform.GetChild(1).GetComponent<Animator>();
        _archSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();

        health = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
            Movement();
        

    }

    public void AddDiamond()
    {
        diamond++;
        UIManager.Instance.UpdateDiamondCount(diamond);
    }

    public void Damage(int Damage)
    {   if(!_death)
        {
            health -= Damage;
            UIManager.Instance.UpdateLives(health);
            if (health < 1)
            {
                _anim.SetTrigger("Death");
                _death = true;
                UIManager.Instance.Dead.SetActive(true);
            }
        }
        
    }

    public void Movement()
    {
       if(!FinishTrigger.Instance._finished && !_death)
        {
            //PC Input
            //horizontal = Input.GetAxisRaw("Horizontal");

            
            horizontal = _input.Player.Movement.ReadValue<Vector2>().x;
        }



        _anim.SetBool("Jump", Grounded());
      
        


        if (horizontal>0)
        {
            _playerSprite.flipX = false;
            _archSprite.flipX = false;
            _archSprite.flipY= false;
            //transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
        }

        else if (horizontal < 0)
        {
            _playerSprite.flipX = true;
            _archSprite.flipX = true;
            _archSprite.flipY = true;
            //transform.rotation = Quaternion.Euler(transform.rotation.x, 180, transform.rotation.z);
        }
        //_input.Player.Jump.triggered

        //PC Input
        //Input.GetKeyDown(KeyCode.Space)
        
        //Touch Input
        //_input.Player.Jump.triggered

        if (_input.Player.Jump.triggered && Grounded())
        {

            StartCoroutine(SmoothJump());

        }

        else if(!attack && !FinishTrigger.Instance._finished && ! _death)          
        {   
            _rb.velocity = new Vector2(horizontal * _speed, _rb.velocity.y);       
        }
        else
        {
            _rb.velocity = Vector2.zero;
        }


        //PC Input
        //Input.GetMouseButtonDown(0)

        //Touch Input
        //_input.Player.Attack.triggered
       
        if (_input.Player.Attack.triggered && Grounded())
        {
            _rb.velocity =  new Vector2(0, _rb.velocity.y);
            Attack();
            attack = true;
            StartCoroutine(WaitforAttack());
        }
       

        _anim.SetFloat("Move", Mathf.Abs(horizontal));
       

    }

    private void Attack()
    {
        _ArcAnim.SetTrigger("Arc");
        _anim.SetTrigger("Attack");
    }

    public bool Grounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, 1 << 6);

        if (hitInfo.collider != null)
        {

            return true;
        }
       
        return false;
        
    }

    public IEnumerator SmoothJump()
    {
        yield return new WaitForSeconds(0.15f);
        _rb.velocity = new Vector2(horizontal * _speed, _jumpHeight);
    }

    public IEnumerator WaitforAttack()
    {
        yield return new WaitForSeconds(0.2f);
        attack = false;
    }

}
