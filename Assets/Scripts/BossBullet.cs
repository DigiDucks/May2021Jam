using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    private Rigidbody2D myRigidbody; // rigid body of the projectile
    [SerializeField] float lifeTimer = 5.0f; //The time the projectile has to live
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetVelocity()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 500f));
    }
}
