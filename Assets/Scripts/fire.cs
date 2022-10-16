using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class fire : MonoBehaviour
{
    public float timer;
    public GameObject fire_attack;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            StartCoroutine(fireattack());
        }
    }
    IEnumerator fireattack()
    {
        yield return new WaitForSeconds(timer);
        _animator.SetTrigger("attack");
        Instantiate(fire_attack, transform.position, Quaternion.identity);
    }
}
