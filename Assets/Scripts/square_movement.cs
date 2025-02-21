using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class square_movement : MonoBehaviour
{
    
    public Gun[] guns;
    public Gun currentGun;
    public Transform handHold;
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    private bool reloading;
    private AmmoGui ammoGUI;
    //public Animator animator;
    Vector2 movement;

    private void Start()
    {
        ammoGUI = GameObject.FindGameObjectWithTag("GUI").GetComponent<AmmoGui>();
        EquipGun(0);
    }
    void EquipGun(int i)
    {
        if (currentGun)
        {
            Destroy(currentGun.gameObject);
        }
        currentGun = Instantiate(guns[i], handHold.position, handHold.rotation) as Gun;
        currentGun.transform.parent = handHold;
        currentGun.ammoGui = ammoGUI;
        

    }
    // Update is called once per frame
    void Update()
    {
        //inputs
        movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = direction;
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        //Button Pressing for equipping guns
        for (int i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyDown((i + 1) + "") || Input.GetKeyDown("[" + (i + 1) + "]"))
            {
                EquipGun(i);
                break;
            }
        }

        fireGun();
    }
    public void fireGun()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            currentGun.shoot();
        }
        else if (Input.GetButton("Fire1"))
        {
            currentGun.automaticFire();
        }
        if (Input.GetButtonDown("Reload"))
        {
            if (currentGun.Reload())
            {
                reloading = true;
            }
        }
        
        if(reloading)
        {
            currentGun.finishReload();
            reloading = false;
        }
    }
    private void FixedUpdate()
    {
        //Movements
        rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
    }

    

    
}
