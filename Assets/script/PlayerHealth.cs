using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxhealth=100;
    public int currenthealth;

    public healtbar healthbar;

    public bool isInvisible = false;
    public SpriteRenderer graphic;

    public float waitvisible;

    public int durationInvicibility = 3;
    public AudioClip Sound;
    public AudioClip Sounddeath;


 public static PlayerHealth instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currenthealth = maxhealth;
        healthbar.SetMaxHealth(maxhealth);
        
    }

    // Update is called once per frame
    void Update()
    {

        //prendre des degats avec la touche H
        if(Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(50);
        }
    }

    public void Heal(int healAmount)
    {
        currenthealth += healAmount;
        if(currenthealth>maxhealth)
        {
            currenthealth = maxhealth;
        }
        healthbar.SetHealth(currenthealth);
    }


 
    public void TakeDamage(int damage)
    {
        if(!isInvisible)
        {
            AudioManager.instance.CreateAudioSource(Sound, transform.position);
           currenthealth -= damage;
        healthbar.SetHealth(currenthealth);

    //verif live
    if(currenthealth<=0){
        Die();
        return;
    }

        isInvisible = true;
        StartCoroutine(Invisibleflash());
        StartCoroutine(HandleInvicibilityDelay());

    
        }
        
    }

    public void Die()
    {
        
        //game over
        AudioManager.instance.CreateAudioSource(Sounddeath, transform.position);
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.enabled = false;
        playerMovement.rb.linearVelocity = Vector2.zero;
        playerMovement.animator.SetTrigger("death");
        playerMovement.rb.bodyType = RigidbodyType2D.Kinematic;
        playerMovement.playercollider.enabled = false;
        GameOverManager.instance.OnPlayerDeath();

    }

    public void Respawn()
    {
        currenthealth = maxhealth;
        healthbar.SetHealth(currenthealth);
        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        
        playerMovement.enabled = true;
        playerMovement.animator.SetTrigger("respawn");
        playerMovement.rb.bodyType = RigidbodyType2D.Dynamic;
        playerMovement.playercollider.enabled = true;
    }

    

    public IEnumerator Invisibleflash()
    {
       while(isInvisible)
       {
           graphic.color= new Color(1f,0f,0f,1f);
           yield return new WaitForSeconds(waitvisible);
           graphic.color= new Color(1f,1f,1f,1f);
           yield return new WaitForSeconds(waitvisible);
       }
    }

    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(durationInvicibility);
        isInvisible = false;
    }

    
}

