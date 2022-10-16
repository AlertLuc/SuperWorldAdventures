using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 5;//�ٶ�
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float x;
    private float y;
    void Start()//����update����֮ǰִ�У�ִֻ��һ��
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();//������Ϸ����
        _animator = GetComponent<Animator>();
        
    }
    void Update()//������ѭ����ÿִ֡��
    {
        x = Input.GetAxis("Horizontal");//��Ӧ�����ϵ�A����D��  ��˿��
        y = Input.GetAxis("Vertical");//��Ӧ W �� S
        if (x > 0)
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(x: 0, y: 0, z: 0);//��ת
            _animator.SetBool(name: "run", value: true);
        }
        else if (x < 0)
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(x: 0, y: 180f, z: 0);
            _animator.SetBool(name: "run", value: true);
        }

        else if (x < 0.001f && x > -0.001f)
        {
            _animator.SetBool(name: "run", value: false);

        }        
        Run();
    }
    private void OnCollisionEnter2D(Collision2D collision)//��ײ
    {
        if(collision.gameObject.tag=="spiketap")//��
        {
            Game._game.GameOver();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="frog")//����
        {
            if((_rigidbody2D.position.y - collision.contacts[0].point.y)>0)
            {       
                Destroy(collision.gameObject);
            }
            else
            {
                Game._game.GameOver();
                Destroy(gameObject);
            }
        }
    }
    private void Run()
    {
        Vector3 movement = new Vector3(x,y,z: 0);
        _rigidbody2D.transform.position += movement * speed * Time.deltaTime;
    }
}
