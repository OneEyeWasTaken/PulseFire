using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    Vector2 _direction;
    bool isReady;
    // Start is called before the first frame update

    private void Awake()
    {   
        speed = 5f;
        isReady = false;
    }
    public void setDirection(Vector2 direction)
    {
        _direction = direction.normalized;

        isReady = true;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(isReady)
        {
            Vector2 position = transform.position;
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if(transform.position.x < min.x || transform.position.x > max.x ||
               transform.position.y < min.y || transform.position.y > max.y)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.gameObject.name == "Player")
        {
            collision.gameObject.GetComponent<Entity>().takeDamage(2);
            Destroy(gameObject);
        }
        
    }
}
