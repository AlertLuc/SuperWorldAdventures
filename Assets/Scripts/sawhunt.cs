using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class sawhunt : MonoBehaviour
{
    public float speed = 2;
    public  float movetime=3;
    private float timer = 0;
    private bool direction=true;
    void Start()
    {     
    }  
    void Update()
    {
        if(direction==true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        timer += Time.deltaTime;
        if(timer>movetime)
        {
            direction = !direction;
            timer = 0;
        }
    }
}
