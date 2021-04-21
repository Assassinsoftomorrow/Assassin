using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.collider.name == "Player") {
            Destroy(gameObject);
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(PlayerHealth.damage);
        }
    }    

}
