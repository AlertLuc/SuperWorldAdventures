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
    private void FixedUpdate()//�̶���֡ 0.02��һ֡ ����
    {
        if(jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocit, ForceMode2D.Impulse);//ʩ���� 
            //Impulse��� rigidbody2D ���˲ʱ�������������������
            jumpRequest = false;
        }
    }
}
