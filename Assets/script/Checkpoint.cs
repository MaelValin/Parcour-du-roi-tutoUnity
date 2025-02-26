using UnityEngine;

public class Checkpoint : MonoBehaviour
{
  
    public AudioClip Sound;

   

   void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("Player"))
       {
        AudioManager.instance.CreateAudioSource(Sound, transform.position);
           CurrentSceneManager.instance.playerspawn = transform.position;
           Destroy(gameObject);
       }
   }
}
