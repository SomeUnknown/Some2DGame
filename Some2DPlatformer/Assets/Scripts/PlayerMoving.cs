using UnityEngine;
using System.Collections;
using System.Threading;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMoving : MonoBehaviour
{
    public GameObject player;
    public float speed = 0;
    public float jumping = 0;
    private Rigidbody2D rb2D;
    private bool isGrounded;

    public void Start()
    {
        player = (GameObject)this.gameObject;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position += new Vector3(-speed, 0, 0);
            player.transform.rotation = Quaternion.Euler(0, 550, 0); 
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.localPosition += new Vector3(speed, 0, 0);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                rb2D.AddForce(transform.up * jumping, ForceMode2D.Impulse);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//חולכÿ הכÿ ןנûזךא
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)//חולכÿ הכÿ ןנûזךאû
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}