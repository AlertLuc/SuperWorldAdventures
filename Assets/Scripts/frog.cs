using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class frog : MonoBehaviour
{
    public float speed = 1;
    public float staytime;
    static float timer;
    public Transform headpos;
    public Transform Tomovepos;
    public Transform leftpos;
    public Transform rightpos;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        Tomovepos.position = GetRandomPos();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>(); 
        timer = staytime;
    } 
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Tomovepos.position, Time.deltaTime * speed);
        if (Vector2.Distance(transform.position, Tomovepos.position) < 0.01f)
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
    private void FixedUpdate()
    {
        float faceDir = Tomovepos.position.x - transform.position.x;  
            //ÅÐ¶Ï·½Ïò
            if (faceDir > 0f)
            {
               _spriteRenderer.flipX = false;
            }
            if (faceDir < 0)
            {
                _spriteRenderer.flipX = true;
            }     
    }
    private Vector2 GetRandomPos()
    {
        Vector2 position = new Vector2(Random.Range(leftpos.position.x, rightpos.position.x), transform.position.y);
        return position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (( collision.contacts[0].point.y-headpos.position.y) > 0)
            {
                Destroy(gameObject);
            }
            else
            {        
                Destroy(collision.gameObject);
                Game._game.GameOver();
            }
        }
    }
}
