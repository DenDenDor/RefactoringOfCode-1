using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayerPauseMenu : MonoBehaviour
{
    [SerializeField] private Pause _pause;
    [SerializeField] private GameObject _pauseMenu;

    private void Awake() 
    {
        _pause.OnChangeActive += ShowMenu;
    }
    private void ShowMenu(bool active) 
    {
        _pauseMenu.SetActive(active);
         Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ResumeButton() 
    {
        ShowMenu(false);
    }

    public void MainMenuButton() 
    {
        ShowMenu(false);
        SceneManager.LoadScene(0);
    }
    private void OnDisable() 
    {
        _pause.OnChangeActive -= ShowMenu;
    }
}
