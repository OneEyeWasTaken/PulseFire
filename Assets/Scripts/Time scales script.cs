using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timescalesscript : MonoBehaviour
{
    public void startNow()
    {  
        SceneManager.LoadScene("BattleField");
        Time.timeScale = 1.0f;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("BattleField");
        Time.timeScale = 1.0f;
    }
}
