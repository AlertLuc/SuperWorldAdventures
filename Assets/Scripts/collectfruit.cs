using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class collectfruit : MonoBehaviour
{
    private int score = 100;
    private SpriteRenderer _spriteRenderer;
    private CircleCollider2D _cirecleCollider2D;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _cirecleCollider2D = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            _spriteRenderer.enabled = false;
            _cirecleCollider2D.enabled = false;
            Game._game.total_score += score;
            Game._game.Updatescore();
        }
    }
}
