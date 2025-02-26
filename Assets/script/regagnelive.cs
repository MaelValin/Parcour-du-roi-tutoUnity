using UnityEngine;

public class regagnelive : MonoBehaviour
{
    public AudioClip Sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();

        if (collision.CompareTag("Player") && playerHealth.currenthealth < playerHealth.maxhealth)
        {
            AudioManager.instance.CreateAudioSource(Sound, transform.position);
           playerHealth.Heal(25);
            Destroy(gameObject);
        }
    }
}



    
   

