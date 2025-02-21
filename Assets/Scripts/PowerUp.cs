using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PlayerStatus status;

    public virtual void heal(float hp)
    {
        status.hitPoints += hp;
        Debug.Log("Healed " + hp + " health!");
    }
}
