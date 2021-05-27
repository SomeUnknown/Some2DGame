using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    bool movingRight;
    bool stop = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 280)
        {
            movingRight = false;
        }
        else if(transform.position.x <= 231)
        {
            movingRight = true;
        }

        if (movingRight && !stop)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (!movingRight && !stop)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.rotation = Quaternion.Euler(0, 550, 0);
        }
    }
}
