using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : Entity
{
    [SerializeField] private TextMeshProUGUI playerHealth;
    [SerializeField] private TextMeshProUGUI playerScore;
    public Gun gun;
    public int score;
    public AmmoGui gui;
    // Start is called before the first frame update
    private void Start()
    {
        gui = FindObjectOfType<AmmoGui>();
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun> ();
        playerHealth.text = "HP: " + hitPoints;
        playerScore.text = "Score: " + score;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.gameObject.tag)
        {
            case "Enemy":
                Destroy(collision.gameObject);
                takeDamage(3);
                updateHP();
                break;

            case "EnemyBullet":
                Destroy(collision.gameObject);
                takeDamage(1);
                updateHP();
                break;

            case "EliteEnemy":
                Destroy(collision.gameObject);
                takeDamage(5);
                updateHP();
                break;
            case "Ammo":
                gun.totalAmmo += 60;
                Destroy(collision.gameObject);
                gui.SetAmmoInfo(gun.totalAmmo, gun.currentAmmo);
                break;
            case "Health":
                hitPoints += 5;
                if(hitPoints >= 15)
                {
                    hitPoints = 15;
                    updateHP();
                }
                else
                {
                    updateHP();
                }               
                Destroy(collision.gameObject);
                break;
        }
    }
    void updateHP()
    {
        playerHealth.text = "HP: " + Mathf.Clamp(hitPoints, 0f, hitPoints);
    }
    public override void Die()
    {
        gameover.SetActive(true);
        base.Die();
        Time.timeScale = 0f;
    }
    public void AddScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        playerScore.text = "Score: " + score;
        Debug.Log(score);
    }
}   
