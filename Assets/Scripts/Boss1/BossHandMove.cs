using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandMove : MonoBehaviour
{
    private Rigidbody2D myRigidbody;            // Rigidbody of the enemy
    int dir = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(myRigidbody.position.y < -4)
        {
            dir = 1;
        }
        if(myRigidbody.position.y > 10.5)
        {
            dir = 0;
        }

        if (dir == 0)
        {
            Vector2 nam = new Vector2(0.0f, -0.2f);
            myRigidbody.position += nam;
        }
        else if (dir == 1)
        {
            Vector2 nam = new Vector2(0.0f, 0.2f);
            myRigidbody.position += nam;
        }
    }
}
