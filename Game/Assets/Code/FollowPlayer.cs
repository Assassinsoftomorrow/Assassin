using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed;
    public float lineOfSight;
    private Transform player;

    public float ShootingRange;
    public float fireRate = 1f;

    private float nextfiretime;
    public GameObject bullet;
    public GameObject bulletParent;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float DistanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (DistanceFromPlayer < lineOfSight && DistanceFromPlayer > ShootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }
        else if (DistanceFromPlayer <= ShootingRange && nextfiretime < Time.time)
        {
            Instantiate(bullet, bulletParent.transform.position, Quaternion.identity);
            nextfiretime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSight);
        Gizmos.DrawWireSphere(transform.position, ShootingRange);
    }
}
