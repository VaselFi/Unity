using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Movement_controller : MonoBehaviour
{

    private Rigidbody2D _playerRB;
    private Animator _playeranimator;
    [SerializeField] float _speed;
    [SerializeField] float jumpVelocity;
    [SerializeField] private GameObject _Apple;
    [SerializeField] private Transform _Applepoint;
    [SerializeField] private float _AppleSpeed;

    float _move;
    bool _jump;
    bool _faceRight = true;
    public bool isGrounded = false;

    private void Awake()
    {
        _playerRB = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        _playeranimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _move = Input.GetAxisRaw("Horizontal");
        _playeranimator.SetFloat("Speed", Mathf.Abs(_move));
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            _playerRB.velocity = Vector2.up * jumpVelocity;
            _jump = true;
            /* Виникли деякі проблеми з встановленням цього стану, поки відкладу.
            _playeranimator.SetBool("isJumping", true);
            */
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject Apple = Instantiate(_Apple, _Applepoint.position, Quaternion.identity);
            Apple.GetComponent<Rigidbody2D>().velocity = transform.right * _AppleSpeed;
            Apple.GetComponent<SpriteRenderer>().flipX = !_faceRight;
            Destroy(Apple, 2f);
        }

    }

    public void OnLanding()
    {
        _playeranimator.SetBool("isJumping", false);
    }

    private void FixedUpdate()

    {
        if(_move>0 && !_faceRight)
        {
            flip();
        }
        else if(_move<0 &&  _faceRight)
        {
            flip();
        }
     
        _playerRB.velocity = new Vector2(_speed * _move, _playerRB.velocity.y);

    }

    
    void flip()
    {
    _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
    }
    
}