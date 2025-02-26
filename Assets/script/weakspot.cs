using UnityEngine;

public class weakspot : MonoBehaviour
{
    public AudioClip Sound;
    public GameObject deathEffect;
   private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            AudioManager.instance.CreateAudioSource(Sound, transform.position);
            Destroy(deathEffect);
        }
        
    }
}
