using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public float speed;
    public int distanceOfPatrol;
    public Transform point;
    bool movingRight = true;
    public float stoppingDistance;
    bool chill = false;
    bool angry = false;
    bool goBack = false;

    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < distanceOfPatrol)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            chill = false;
            angry = true;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            angry = false;
            goBack = true;
        }

        if (chill)
        {
            Chill();
        }
        else if (angry)
        {
            Angry();
        }
        else if (goBack)
        {
            GoBack();
        }
    }

    void Chill()
    {
        if (transform.position.x > point.position.x + distanceOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - distanceOfPatrol)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
    }

    void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
    }
}
