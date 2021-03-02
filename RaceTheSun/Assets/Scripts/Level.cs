using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float transitionDelay = 2f;

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(1);
    }

    IEnumerator GameWin()
    {
        yield return new WaitForSeconds(transitionDelay);
        SceneManager.LoadScene(2);
    }

    public void loadGameOver()
    {
        StartCoroutine(GameOver());
    }

    public void loadGameWin()
    {
        StartCoroutine(GameWin());
    }

    public void loadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        print("Closing Application...");
        Application.Quit();
    }
}
