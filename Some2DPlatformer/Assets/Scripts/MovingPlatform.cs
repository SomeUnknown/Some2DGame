using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 340)
        {
            movingRight = false;
        }
        else if(transform.position.x <= 215)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position += new Vector3(speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.position += new Vector3(-speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 550, 0);
        }
    }
}
