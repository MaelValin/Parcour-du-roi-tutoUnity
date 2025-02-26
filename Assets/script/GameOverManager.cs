using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;

    public static GameOverManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de GameOverManager dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
    }
    
  public void OnPlayerDeath()
    {
       

        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        inventaire.instance.RemoveCoins(CurrentSceneManager.instance.coinPickedUpthisScenecount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerHealth.instance.Respawn();
        
        gameOverUI.SetActive(false);
    }

    public void MenuButton()
    {

       SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
