using UnityEngine;

public class Movement : MonoBehaviour
{   
    private float horizontalMovement;
    public float moveSpeed; 
    public float jumpForce;     
    private bool isJumping;
    private bool isGrounded;
    public Transform GroundCheck;
    public LayerMask GroundLayer;

    public float wallSidingSpeed;
    private bool isWallSliding;
    private bool isWalledRight;
    private bool isWalledLeft;
    public Transform WallCheckRight;
    public Transform WallCheckLeft;
    public LayerMask WallLayer;

    private bool isWallJumping;
    private float wallJumpingDirection;
    public float wallJumpingTime;
    private float wallJumpingCounter;
    public float wallJumpingDuration;
    public Vector2 wallJumpingForce = new Vector2(8f, 16f);

    public Rigidbody2D rb; //Permet d'insérer le rigidbody du pingouin
    public Animator animator; // idem mais pour l'animation
    public SpriteRenderer spriteRenderer; //Visuel du perso de base

    private Vector3 velocity = Vector3.zero;


    void Update()
    {
        // Détection de l'entrée utilisateur pour le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }

        if (isWallSliding)
        {
            moveSpeed = 0.5f;
        }
        else 
        {
            moveSpeed = 250f;
        }

        MovePlayer();
        WallSlide();
        WallJump();

        if (!isWallJumping)
        {
            Flip(rb.velocity.x); //permet que ça soit positif ou negatif
        }
    }


    void FixedUpdate()
    {   // Vérifie si le personnage touche pour le sol et le mur
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position,0.2f, GroundLayer);
        isWalledRight = Physics2D.OverlapCircle(WallCheckRight.position, 0.2f, WallLayer);
        isWalledLeft = Physics2D.OverlapCircle(WallCheckLeft.position, 0.2f, WallLayer);

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; //Déplacement horizontal + la vitesse de déplacement

        float characterVelocity = Mathf.Abs(rb.velocity.x); //permet que la vitesse soit toujours positif
        animator.SetFloat("Speed", characterVelocity);
    }

    void MovePlayer()
    {
        Vector3 targetVelocity = new Vector2(horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void WallSlide()
    {
        if ((isWalledRight||isWalledLeft) && !isGrounded && horizontalMovement != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = isWalledRight ? -1f : 1f;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingForce.x, wallJumpingForce.y);
            wallJumpingCounter = 0f;

            Flip(rb.velocity.x);
            
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}