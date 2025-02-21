using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyStatus : Entity
{
    public PlayerStatus player;
    public Gun gun;
    public int ScoreOnDeath;
    private void Start()
    {
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            takeDamage(gun.damage);
        }
    }
    public override void Die()
    {
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        player.AddScore(ScoreOnDeath);
        base.Die();
    }
}
