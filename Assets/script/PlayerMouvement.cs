using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed;
    public float jumpforce;

    private bool isJumping;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool isClimbing;

    public Transform groundcheck;
    public float groundcheckradius;

    public LayerMask collisionlayer;

    public CapsuleCollider2D playercollider;
    

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;


    private Vector3 velocity = Vector3.zero;

    private float Horizontalmouvement;
    private float Verticalmouvement;
    
    public static PlayerMovement instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
            return;
        }
        else
        {
            instance = this;
        }
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, collisionlayer);
        MovePlayer(Horizontalmouvement, Verticalmouvement);
       
    }

      void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isClimbing)
        {
            isJumping = true;
        }

         

        Horizontalmouvement = Input.GetAxis("Horizontal") * movespeed;
        Verticalmouvement = Input.GetAxis("Vertical") * movespeed;


        Flip(rb.linearVelocity.x);

        float characterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("speed",  characterVelocity);

        float characterVelocityY = Mathf.Abs(rb.linearVelocity.y);
        animator.SetFloat("speedY", characterVelocityY);
        animator.SetBool("isclimbing", isClimbing);

        
    }

    void MovePlayer(float _Horizontalmouvement, float _Verticalmouvement)
    {
        if(!isClimbing){
            Vector3 targetvelocity = new Vector2(_Horizontalmouvement, rb.linearVelocity.y);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetvelocity, ref velocity, .05f);

            if(isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpforce));
                isJumping = false;
            }
        }else{
             Vector3 targetvelocity = new Vector2(0, Verticalmouvement);
            rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetvelocity, ref velocity, .05f);

        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
    }else if(_velocity < -0.1f)
    {
        spriteRenderer.flipX = true;
    }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundcheck.position, groundcheckradius);
    }
}
