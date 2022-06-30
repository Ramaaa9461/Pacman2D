using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void OnLevel()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnExit()
    {
        Application.Quit();
    }

    public void openCreditsLink(string url)
    {
        Application.OpenURL(url);
    }

}
