using UnityEngine;
using UnityEngine.UI;

public class openchest : MonoBehaviour
{

    private Text textInteract;
    private bool isInRange;
    public Animator animator;
    public bool CloseChest=true;
    public int coinsToAdd;
    public AudioClip Sound;


    void Awake()
    {
                textInteract = GameObject.FindGameObjectWithTag("textInteract").GetComponent<Text>();

    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& isInRange&&CloseChest)
        {

            CloseChest=false;
            OpenChestanimation();
            inventaire.instance.AddCoins(coinsToAdd);
        }
    }

    public void OpenChestanimation()
    {
        AudioManager.instance.CreateAudioSource(Sound, transform.position);
        animator.SetTrigger("openchest");
        textInteract.enabled= false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&& CloseChest)
        {
            textInteract.enabled= true;
            isInRange=true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textInteract.enabled= false;
            isInRange=false;
        }
    }
}
