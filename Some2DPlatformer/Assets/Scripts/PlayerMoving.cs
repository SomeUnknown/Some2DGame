using UnityEngine;
using System.Collections;
using System.Threading;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rb;
    public float health;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;


    [SerializeField]
    public float speed;
    [SerializeField]
    public float jumpForce;
    [SerializeField]
    public Transform groundCheck;

    private bool isGrounded;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (health > numOfHearts)
            health = numOfHearts;
        for (var i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }

        if (health < 1)
            SceneManager.LoadScene(1);
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