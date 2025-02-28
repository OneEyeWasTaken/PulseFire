using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    
    public void EnterShop()
    {
        SceneManager.LoadScene("Shop");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
