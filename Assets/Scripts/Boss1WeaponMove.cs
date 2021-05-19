using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1WeaponMove : MonoBehaviour
{
    private Rigidbody2D myRigidbody;            // Rigidbody of the enemy


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(myRigidbody.name.Contains("Weapon1"))
        {
            BossHandMove[] hands = FindObjectsOfType<BossHandMove>();
            if(hands[0].name.Contains("Hand1"))
            {
                Rigidbody2D theirRigidBody = hands[0].GetComponent<Rigidbody2D>();
                myRigidbody.position = theirRigidBody.position;
            }
            if (hands[1].name.Contains("Hand1"))
            {
                Rigidbody2D theirRigidBody = hands[1].GetComponent<Rigidbody2D>();
                myRigidbody.position = theirRigidBody.position;
            }
        }
        if (myRigidbody.name.Contains("Weapon2"))
        {
            BossHandMove[] hands = FindObjectsOfType<BossHandMove>();
            if (hands[0].name.Contains("Hand2"))
            {
                Rigidbody2D theirRigidBody = hands[0].GetComponent<Rigidbody2D>();
                myRigidbody.position = theirRigidBody.position;
            }
            if (hands[1].name.Contains("Hand2"))
            {
                Rigidbody2D theirRigidBody = hands[1].GetComponent<Rigidbody2D>();
                myRigidbody.position = theirRigidBody.position;
            }
        }
    }
}
