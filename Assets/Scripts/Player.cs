using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    public float speed = 5;//速度
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float x;
    private float y;
    void Start()//进入update函数之前执行，只执行一次
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();//访问游戏对象
        _animator = GetComponent<Animator>();
        
    }
    void Update()//程序主循环，每帧执行
    {
        x = Input.GetAxis("Horizontal");//对应键盘上的A键和D键  更丝滑
        y = Input.GetAxis("Vertical");//对应 W 和 S
        if (x > 0)
        {
            _rigidbody2D.transform.eulerAngles = new Vector3(x: 0, y: 0, z: 0);//旋转
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
    private void OnCollisionEnter2D(Collision2D collision)//碰撞
    {
        if(collision.gameObject.tag=="spiketap")//轮
        {
            Game._game.GameOver();
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="frog")//青蛙
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
