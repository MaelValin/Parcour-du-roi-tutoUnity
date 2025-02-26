using UnityEngine;
using UnityEngine.UI;

public class DialogueTigger : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isInRange;
    public Text textInteract;

    void Awake()
    {
        textInteract = GameObject.FindGameObjectWithTag("textInteract").GetComponent<Text>();
    }

    void Update()
    {
        if(isInRange && Input.GetKeyDown(KeyCode.E)&&DialogueManager.instance.isDialogue==false)
        {
            TriggerDialogue();
        }
        

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textInteract.enabled = true;
            isInRange = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textInteract.enabled = false;
            isInRange = false;
            DialogueManager.instance.EndDialogue();
        }
    }

    void TriggerDialogue()
    {
        
        DialogueManager.instance.StartDialogue(dialogue);
        
    }
}
