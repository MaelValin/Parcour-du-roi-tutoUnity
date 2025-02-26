using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class loadSpecificscene : MonoBehaviour
{

    public string sceneName;
    public Animator fondnoir;
    public Text textInteract;
    public Animator Buttonpause; 
    public AudioClip Sound;
    public Animator porte;
    

    private void Awake()
    {
        fondnoir = GameObject.FindGameObjectWithTag("fondnoir").GetComponent<Animator>();
        textInteract = GameObject.FindGameObjectWithTag("textInteract").GetComponent<Text>();
        Buttonpause = GameObject.FindGameObjectWithTag("ButtonPause").GetComponent<Animator>();
        porte= GameObject.FindGameObjectWithTag("porte").GetComponent<Animator>();
    }

  private Collider2D collision;

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      this.collision = collision;
      textInteract.enabled= true;
     
    }
    
  }

   private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
          this.collision = null;
            textInteract.enabled= false;
        }
    }

  public void Update()
  {

    if (collision != null && collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E)&&sceneName=="fin")
    {
      AudioManager.instance.CreateAudioSource(Sound, transform.position);
      PlayerHealth.instance.Die();
      loadandsavedata.instance.SaveData();
    }
    else if (collision != null && collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
    {
      
      AudioManager.instance.CreateAudioSource(Sound, transform.position);
      StartCoroutine(LoadnewScene());
    
    }

    
  }

  public IEnumerator LoadnewScene()
  {
    loadandsavedata.instance.SaveData();
      textInteract.enabled = false;
      this.collision = null;
      porte.SetTrigger("fadein");
      yield return new WaitForSeconds(0.1f);
    Buttonpause.SetTrigger("fadein");
    fondnoir.SetTrigger("fadein");
  
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(sceneName);
    
    
    
    
  }

  
}
