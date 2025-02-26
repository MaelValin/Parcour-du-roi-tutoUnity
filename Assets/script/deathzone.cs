using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class deathzone : MonoBehaviour
{

public Animator fondnoir;


public Animator Buttonpause;


    private void Awake()
    {
        fondnoir = GameObject.FindGameObjectWithTag("fondnoir").GetComponent<Animator>();
Buttonpause = GameObject.FindGameObjectWithTag("ButtonPause").GetComponent<Animator>();
    }
    
    private Collider2D playerCollision;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerCollision = collision;
            StartCoroutine(Loadrevive()); 
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
           playerHealth.TakeDamage(10);
        }

    }


    public IEnumerator Loadrevive()
  {
    Buttonpause.SetTrigger("fadein");
    fondnoir.SetTrigger("fadein");
    PlayerMovement.instance.enabled = false;
    yield return new WaitForSeconds(1f);
    playerCollision.transform.position = CurrentSceneManager.instance.playerspawn;
    yield return new WaitForSeconds(1f);
    PlayerMovement.instance.enabled = true;
    
  }

  
}
