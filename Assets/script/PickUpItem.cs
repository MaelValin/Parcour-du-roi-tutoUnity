using UnityEngine;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
   
    private Text textInteract;
    private bool isInRange;
    
    public Item item;
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
        if(Input.GetKeyDown(KeyCode.E)&& isInRange)
        {

            TakeItem();
        }
    }

    public void TakeItem()
    {
        inventaire.instance.AddItem(item,1);
        //AudioManager.instance.CreateAudioSource(Sound, transform.position);
        textInteract.enabled= false;
        Destroy(gameObject);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
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