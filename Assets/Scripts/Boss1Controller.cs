using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss1Controller : MonoBehaviour
{
    private Rigidbody2D myRigidbody;            // Rigidbody of the enemy
    [SerializeField] int health = 100;          // Health of the boss
    [SerializeField]Text healthText;            // Text of the health

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        healthText.text = "Boss Health: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        healthText.text = "Boss Health: " + health.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            if(collision.gameObject.GetComponent<PlayerSwordAttack>().IsSwordCharged())
            {
                health -= 3;
            }
            else
            {
                health--;
            }
        }
    }
}
