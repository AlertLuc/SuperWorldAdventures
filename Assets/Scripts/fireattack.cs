using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fireattack : MonoBehaviour
{
    public float destroytime;
    private Animator _animator; 
    void Start()
    {  
        Destroy(gameObject, destroytime);
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Game._game.GameOver();
        }      
    }   
}
