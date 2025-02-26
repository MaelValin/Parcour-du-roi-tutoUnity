using UnityEngine;

public class pickupcoin : MonoBehaviour
{


public AudioClip pickupSound;
    
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.CreateAudioSource(pickupSound, transform.position);
            inventaire.instance.AddCoins(1);
            CurrentSceneManager.instance.coinPickedUpthisScenecount++;
            Destroy(gameObject);
        }
    }

    
}
