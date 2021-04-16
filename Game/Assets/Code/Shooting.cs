using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{


    public Transform firePoint;
    public Transform firePointLeft;
    public GameObject bulletPrefab;

    public float bulletForce = 7f;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        Vector2 shootDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - firePoint.position;
        float angle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        firePoint.transform.Rotate(0, 0, angle - firePoint.eulerAngles.z - 90);

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 1);
    }
}
