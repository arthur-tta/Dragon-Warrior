using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScene;

    private void Awake()
    {
        gameOverScene.SetActive(false);
    }


    // Active game over screne
    public void GameOver()
    {
        gameOverScene.SetActive(true);
    }

    // game over funtions

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0); // load scene dau tien - menu scene
    }

    public void Quit()
    {
        Application.Quit(); // hoat dong khi build thanh sp

        UnityEditor.EditorApplication.isPlaying = false; // dung trinh editor unity
    }
}
