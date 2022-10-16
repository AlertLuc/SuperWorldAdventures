using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Jump : MonoBehaviour
{
    public float jumpVelocit = 5f;
    private Rigidbody2D _rigidbody2D;
    private bool jumpRequest = false;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }
    private void FixedUpdate()//固定的帧 0.02秒一帧 物理
    {
        if(jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocit, ForceMode2D.Impulse);//施加力 
            //Impulse向此 rigidbody2D 添加瞬时力冲击，考虑其质量。
            jumpRequest = false;
        }
    }
}
