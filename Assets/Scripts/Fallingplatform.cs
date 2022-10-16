using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingplatform : MonoBehaviour
{
    public float fallingTime = 3;
    private TargetJoint2D _targetJoint2D;
    private BoxCollider2D _boxCollider2D;
    void Start()
    {      
        _targetJoint2D = GetComponent<TargetJoint2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
    } 
    void Update()
    { 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Invoke(methodName: "Falling", fallingTime);
        }
        if(collision.gameObject.tag=="spiketap")
        {
            Destroy(gameObject);
        }
    }
    private void Falling()
    {
        _targetJoint2D.enabled = false;
        _boxCollider2D.enabled = false;
    }
}
