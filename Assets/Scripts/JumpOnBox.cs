using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpOnBox : MonoBehaviour
{
    public float jumpVelocity = 9f;
    public LayerMask mask;
    public float boxHeight=0.1f;
    private Vector2 playersise;
    private Vector2 boxsise;
    private bool jumpRequest = false;
    private bool ground = false;
    private Rigidbody2D _rigidbody2D;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playersise = GetComponent<SpriteRenderer>().bounds.size;
        boxsise = new Vector2(x:playersise.x * 0.3f, y:boxHeight);
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && ground)
        {
            jumpRequest = true;
        }
    }
    private void FixedUpdate()
    {
        if(jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
            jumpRequest = false;
            ground = false;
        }
        else
        {
            Vector2 boxcenter = (Vector2)transform.position + (Vector2.down * playersise.y *0.5f);
            if (Physics2D.OverlapBox(boxcenter, boxsise, 0, mask) != null)
            {
                ground = true;
            }
            else
            {
                ground = false;
            }
        }
    }
}
