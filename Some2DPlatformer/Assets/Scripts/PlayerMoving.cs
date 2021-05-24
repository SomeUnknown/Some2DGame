using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoving : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpForce;
    [SerializeField]
    public Transform groundCheck;

    private bool isGrounded;

    public void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground")))
            isGrounded = true;
        else
            isGrounded = false;

        if (Input.GetKey(KeyCode.D) && Time.deltaTime != 0)
        {
            transform.position += new Vector3(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.A) && Time.deltaTime != 0)
        {
            transform.position += new Vector3(-speed , 0, 0);
            transform.rotation = Quaternion.Euler(0, 550, 0);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded && Time.deltaTime != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Restarter")
            SceneManager.LoadScene(1);
    }
}