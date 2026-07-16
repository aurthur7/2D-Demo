using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }
    public void BacktoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
