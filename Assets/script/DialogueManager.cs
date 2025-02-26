using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public GameObject dialogueBox;
    public GameObject PNJ;
    public bool isDialogue=false;
    public AudioClip Sound;

    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {

        
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
         sentences = new Queue<string>();
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true;
        dialogueBox.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
           EndDialogue();
            return;
        }else{
        AudioManager.instance.CreateAudioSource(Sound, transform.position);
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void EndDialogue()
    {
        StartCoroutine(EndDialoguecarou());
    }

    IEnumerator EndDialoguecarou()
    {
        
        dialogueBox.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isDialogue = false;
    }

    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }
}
