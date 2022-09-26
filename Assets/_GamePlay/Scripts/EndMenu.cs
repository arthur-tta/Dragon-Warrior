using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }
    /*
    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}
