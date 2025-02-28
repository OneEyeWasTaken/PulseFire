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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
    }

    public void QuitNow()
    {
        Application.Quit();
    }
}
