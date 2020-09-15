using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float CurrentAnswer;
    public float speed = 10f;
    public float jumpForce;
    private float moveInput;
    private Rigidbody2D rb;
    Animator anim;
    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpValue;
    public Button scrollButton;
    public Button scrollSecondButton;

    public InputField inputAnswer;
    public Button ok;
    public QuestionManController state;
    private ScrollController scrollController;
    public GameObject respawn;

    void Start()
    {
        scrollController = FindObjectOfType<ScrollController>();
        extraJumps = extraJumpValue;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        if (GameState.IsPaused){
            moveInput = 0;
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            anim.SetInteger("sost", 1);
        }
        else
        {
            anim.SetInteger("sost", 2);
        }
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Update()
    {
        if (GameState.IsPaused)
            return;
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
            Debug.Log(extraJumps);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var scrollTag = other.GetComponent<ScrollTag>();
        if (scrollTag != null)
        {
            scrollController.TakeScroll(scrollTag.scroll);
            scrollButton.gameObject.SetActive(true);
            Destroy(scrollTag.gameObject);
        }
        if (other.gameObject.tag == "triggerZone")
        {
            state = other.gameObject.GetComponent<TriggerZoneController>().GetMainController();
            SetInputState(true);
        }
        if (other.tag == "checkpoint")
        {
            respawn.transform.position = other.transform.position;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D scroll)
    {
        if (scroll.gameObject.tag == "triggerZone")
        {
            SetInputState(false);
        }
    }

    public void CheckAnswer()
    {
        if (float.TryParse(inputAnswer.text.Replace('.',','), out var myFloatAnswer) && state != null)
        {
            var isResolved = state.Resolve(myFloatAnswer);
            inputAnswer.text = string.Empty;
            if (isResolved)
            {
                SetInputState(false);
                state = null;
            }
        }
    }
    private void SetInputState(bool active)
    {
        inputAnswer.gameObject.SetActive(active);
        ok.gameObject.SetActive(active);
    }
}
