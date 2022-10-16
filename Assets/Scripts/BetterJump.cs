using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BetterJump : MonoBehaviour
{
    public float fallMutiplier = 2.5f;
    public float lowjumpMutiplier = 2f;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.gravityScale = fallMutiplier;
        }
        else if(_rigidbody2D.velocity.y>0&&!Input.GetButton("Jump"))
        {
            _rigidbody2D.gravityScale = lowjumpMutiplier;
        }
        else
        {
            _rigidbody2D.gravityScale = 1f;
        }
    }
}
