using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PresentationCommand : MonoBehaviour
{

    public Animator fondnoir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadstartScene("levelchoose"));
    }

   public IEnumerator LoadstartScene(string levelToLoad)
  {
    yield return new WaitForSeconds(5f);
    fondnoir.SetTrigger("fadein");
    
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(levelToLoad);
    
    
  }
}
