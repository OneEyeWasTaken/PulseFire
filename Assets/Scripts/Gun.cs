using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [HideInInspector] public AmmoGui ammoGui;
    public enum GunType {pistol, auto}
    public float gunID;
    public GunType fireSelect;
    public float roundsPerMinute;
    public float speed;
    public float damage;

    private float shotsBetweenSeconds;
    private float nextShootTime;

    public int totalAmmo;
    public int ammoPerMagazine;
    public int currentAmmo;
    private bool reloading;

    void Start()
    {
        //rpm means rounds per minutes 60 kasi 60 seconds
        shotsBetweenSeconds = 60 / roundsPerMinute;

        currentAmmo = ammoPerMagazine;
        ammoGui.SetAmmoInfo(totalAmmo, currentAmmo);
    }

    public void shoot()
    {
        if(canShoot())
        { 
            GameObject projectile = Instantiate(bulletPrefab, firingPoint.position, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = /*bs.speed*/12f * transform.up;
                //projectile.transform.position = firingPoint.transform.position;
                //Pistol bulletScript = projectile.GetComponent<Pistol>();
                nextShootTime = Time.time + shotsBetweenSeconds;
            
            currentAmmo--;
            
           Debug.Log("currentAmmo: " + currentAmmo + " Total Ammo: " + totalAmmo);
           if(ammoGui)
            {
                ammoGui.SetAmmoInfo(totalAmmo, currentAmmo);
            }
        }
    }

    private bool canShoot()
    {
        bool canshoot = true;
        if(Time.time < nextShootTime)
        {
            canshoot = false;
        }
        if(currentAmmo == 0)
        {
            canshoot = false;
        }
        if(reloading)
        {
            canshoot = false;
        }
        return canshoot;
    }

    public bool Reload()
    {
        if(totalAmmo != 0 && currentAmmo != ammoPerMagazine)
        {
            reloading = true;   
            return true;
        }
        return false;
    }
    public void finishReload()
    {
        reloading = false;

        if (totalAmmo > -ammoPerMagazine - currentAmmo)
        {
            totalAmmo -= ammoPerMagazine - currentAmmo;
            currentAmmo = ammoPerMagazine;
        }
        if (totalAmmo < ammoPerMagazine - currentAmmo)
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }

        if (totalAmmo < 0)
        {
            currentAmmo += totalAmmo;
            totalAmmo = 0;
        }
        if (ammoGui)
        {
            ammoGui.SetAmmoInfo(totalAmmo, currentAmmo);
        }


    }
    public void automaticFire()
    {
        if(fireSelect == GunType.auto)
        {
            shoot();
        }
    }
    public void PickupAmmo(int refill)
    {
        totalAmmo += refill;
        ammoGui.SetAmmoInfo(totalAmmo, currentAmmo);
        Debug.Log("currentAmmo: " + currentAmmo + " Total Ammo: " + totalAmmo);
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
