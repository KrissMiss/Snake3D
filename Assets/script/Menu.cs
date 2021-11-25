using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void OnPlayHandler()
    {
        SceneManager.LoadScene(1);
    }

    public void AboutGame()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
