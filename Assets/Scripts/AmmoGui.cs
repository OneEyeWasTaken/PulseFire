using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoGui : MonoBehaviour
{
    public TextMeshProUGUI ammo;
   public void SetAmmoInfo(int totalAmmo, int ammoInMag)
    {
        ammo.text = ammoInMag + "/" + totalAmmo;
    }
}
