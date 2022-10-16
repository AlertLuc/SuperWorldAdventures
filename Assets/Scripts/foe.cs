using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foe : MonoBehaviour
{
    public float speed = 1;
    public float staytime ;
    static float timer;
    public Transform Tomovepos;
    public Transform leftpos;
    public Transform rightpos;
    void Start()
    { 
        Tomovepos.position = GetRandomPos();
        timer = staytime;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Tomovepos.position, Time.deltaTime * speed);
        if(Vector2.Distance(transform.position,Tomovepos.position)<0.1f)
        {
            if (timer <= 0)
            {
                Tomovepos.position = GetRandomPos();
                timer = staytime;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
    private Vector2 GetRandomPos()
    {
        Vector2 position = new Vector2(Random.Range(leftpos.position.x, rightpos.position.x), 
            Random.Range(leftpos.position.y, rightpos.position.y));
        return position;
    }
}
