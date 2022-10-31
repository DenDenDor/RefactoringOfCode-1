using UnityEngine.SceneManagement;

public class PlayerHealth : BasicHealthSystem
{
    protected override void Die() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
