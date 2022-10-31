using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayTheGame() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitTheGame() 
    {
        Application.Quit();
    }
}
