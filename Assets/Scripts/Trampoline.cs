using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Trampoline : MonoBehaviour
{
    public float jumpVelocity=22;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            _animator.SetTrigger("jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(x: 0, y: jumpVelocity), ForceMode2D.Impulse);
        }
    }
}
