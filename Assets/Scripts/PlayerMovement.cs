using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float dirX;

    [SerializeField]

    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode jump = KeyCode.Space;

    public float speedMultiplier = 5.0f;
    public float jumpPower = 15.0f;
    public Transform groundDetection;
    public LayerMask ground;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool x2Jump = false;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newMovement;

        isGrounded = Physics2D.OverlapCircle(groundDetection.position, 0.1f, ground);

        Debug.Log("isGrounded: " + isGrounded);

        if (Input.GetKey(moveLeft)) //Movement Speed Left
        {
            newMovement = new Vector2(rb.position.x - (Time.deltaTime * speedMultiplier), rb.position.y);
            rb.position = newMovement;
        }

        if (Input.GetKey(moveRight)) //Movement Speed Right
        {
            newMovement = new Vector2(rb.position.x + (Time.deltaTime * speedMultiplier), rb.position.y);
            rb.position = newMovement;
        }

        if (rb.velocity.y == 0)
        {
            isGrounded = true;
        }
        else isGrounded = false;

        if (isGrounded)
        {
            x2Jump = true;
        }

        if (isGrounded && Input.GetKeyDown(jump)) //Detects if you're in the ground and are you pressing the jump key?
        {
            Debug.Log("I am jumping.");
            Jumping();
        }
        else if (x2Jump && Input.GetKeyDown(jump))
        {
            Jumping();
            Debug.Log("I am Double Jumping.");
            x2Jump = false;
        }
        dirX = Input.GetAxis("Horizontal") * speedMultiplier;
    }

    private void FixedUpdate() //Jumping Mechanic
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
