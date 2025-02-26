using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{

    public GameObject parametreMenu;
    public Animator fondnoir;

   public void StartGameButton()
    {
        StartCoroutine(LoadstartScene("CommandPresent"));
        
        
    } 

    public void SettingButton()
    {
        parametreMenu.SetActive(true);
    }

    public void CloseSettingButton()
    {
        parametreMenu.SetActive(false);
    }
    public void CreditButton()
    {
        SceneManager.LoadScene("credit");
    } 

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator LoadstartScene(string levelToLoad)
  {
    
    fondnoir.SetTrigger("fadein");
    
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(levelToLoad);
    
    
  }
}
