using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    [SerializeField] private GameObject EnemyBullet;
    [SerializeField] private float bulletsPerSecond = 0.75f;
    private float timeUntilFire;
    private Vector2 offset;
    // Start is called before the first frame update
    /*void Awake()
    {
        Invoke("FireBullet", 0.1f);
    }*/
    private void Start()
    {
        offset = new Vector2(Random.Range(-0.75f,0.75f), 0);
    }
    void Update()
    {
        GameObject playership = GameObject.Find("Player");
        if (playership != null)
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / Random.Range(0, bulletsPerSecond))
            {
                GameObject bullet = (GameObject)Instantiate(EnemyBullet);
                bullet.transform.position = transform.position;
                Vector2 direction = (playership.transform.position - bullet.transform.position) - (Vector3) offset;
                bullet.GetComponent<EnemyBullet>().setDirection(direction);
                timeUntilFire = 0f;
            }
        }
    }
    /*void FireBullet()
    {
        GameObject playership = GameObject.Find("Player");

        if(playership != null)
        {
            timeUntilFire += Time.deltaTime;
            if (timeUntilFire >= 1f / bulletsPerSecond)
            {
                GameObject bullet = (GameObject)Instantiate(EnemyBullet);
                bullet.transform.position = transform.position;
                Vector2 direction = playership.transform.position - bullet.transform.position;
                bullet.GetComponent<EnemyBullet>().setDirection(direction);
                timeUntilFire = 0f;
            }
        }
    }*/
}
