using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Image controllersImage;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ShowControllers()
    {
        controllersImage.gameObject.SetActive(true);
    }
    public void HideControllers()
    {
        controllersImage.gameObject.SetActive(false);
    }
}
