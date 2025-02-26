using UnityEngine;
using UnityEngine.UI;

public class echelle : MonoBehaviour
{

    private bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D topcollider;
    public Text textInteract;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        textInteract = GameObject.FindGameObjectWithTag("textInteract").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = playerMovement.isGrounded;
        float playerVelocityY = playerMovement.GetComponent<Rigidbody2D>().linearVelocity.y;
        

        if(isInRange && playerMovement.isClimbing && (Input.GetKeyDown(KeyCode.E) || (isGrounded && playerVelocityY == 0 && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))))
        {
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            return;
        }

        if(isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
            topcollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            isInRange = true;
            textInteract.enabled= true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            topcollider.isTrigger = false;
            textInteract.enabled= false;
        }
    }
}
