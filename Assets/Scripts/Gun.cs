using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    public enum GunType {pistol, auto}
    public float gunID;
    public GunType fireSelect;
    public float roundsPerMinute;
    public float speed;

    private float shotsBetweenSeconds;
    private float nextShootTime;

    void Start()
    {
        //rpm means rounds per minutes 60 kasi 60 seconds
        shotsBetweenSeconds = 60 / roundsPerMinute;
    }

    public void shoot()
    {
        if(canShoot())
        { 
            GameObject projectile = Instantiate(bulletPrefab, firingPoint.position, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = /*bs.speed*/8f * transform.up;
                //projectile.transform.position = firingPoint.transform.position;
                //Pistol bulletScript = projectile.GetComponent<Pistol>();
                nextShootTime = Time.time + shotsBetweenSeconds;
        }
    }

    private bool canShoot()
    {
        bool canshoot = true;
        if(Time.time < nextShootTime)
        {
            canshoot = false;
        }
        return canshoot;
    }

    public void automaticFire()
    {
        if(fireSelect == GunType.auto)
        {
            shoot();
        }
    }

    /*void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
        Vector2 cam = Camera.main.ViewportToWorldPoint(new Vector2 (1, 1));
        if(transform.position.y > cam.y)
        {
            Destroy(gameObject);
        }

    }*/
}
