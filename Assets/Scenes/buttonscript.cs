using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonscript : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameButn(string newGamelevel)
    {
        SceneManager.LoadScene(newGamelevel);
    }
    public void GameButn1(string newGamelevel)
    {
        SceneManager.LoadScene(newGamelevel);
    }
    public void ExitButn()
    {
        Debug.Log("Exited");
        Application.Quit();
    }
}
