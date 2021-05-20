using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss4Controller : MonoBehaviour
{
    private Rigidbody2D myRigidbody; // rigid body of the projectile
    [SerializeField] int health = 100;          // Health of the boss
    [SerializeField] Text healthText;            // Text of the health
    float timer = 0.0f;
    int phase = 1;
    [SerializeField] ParticleSystem _particles;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        healthText.text = "Boss Health: " + health.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            _particles.transform.position = gameObject.transform.position;
            _particles.Play();
            Destroy(gameObject);
        }
        if(health <=67)
        {
            phase = 2;
        }
        if(health <= 33)
        {
            phase = 3;
        }
        if (phase == 1)
        {
            if (timer < 5.0f)
            {
                Boss4Sword swo = FindObjectOfType<Boss4Sword>();
                swo.Idle();
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.red;
                PlayerMovement player = FindObjectOfType<PlayerMovement>();

                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();

                myRigidbody.velocity = direction * 2.0f;
            }
            else if (timer > 5.0f && timer < 6.0f)
            {
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = new Color(0, 0, 1);
                Boss4Sword swo = FindObjectOfType<Boss4Sword>();
                swo.Swing();
            }
            else
            {
                Boss4Sword swo = FindObjectOfType<Boss4Sword>();
                swo.Idle();
                myRigidbody.velocity = new Vector2(0, 0);
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.green;

            }
            if(timer>=8.0f && timer<9.0f)
            {
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.yellow;
            }
            if (timer > 9.0f)
            {
                timer = 0;
                Debug.Log("work");
            }
        }
        else if(phase == 2)
        {
            if (timer < 5.0f)
            {
                Boss4Sword swo = FindObjectOfType<Boss4Sword>();
                swo.Swing();
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.blue;
                PlayerMovement player = FindObjectOfType<PlayerMovement>();

                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();

                myRigidbody.velocity = direction * 3.0f;
            }
            else
            {
                Boss4Sword swo = FindObjectOfType<Boss4Sword>();
                swo.Idle();
                myRigidbody.velocity = new Vector2(0, 0);
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.green;

            }
            if (timer >= 10.0f && timer < 11.0f)
            {
                Renderer render = myRigidbody.GetComponent<Renderer>();
                render.material.color = Color.yellow;
            }
            if (timer > 11.0f)
            {
                timer = 0;

            }
        }
        else
        {
            Boss4Sword swo = FindObjectOfType<Boss4Sword>();
            swo.Slow();
            Renderer render = myRigidbody.GetComponent<Renderer>();
            render.material.color = Color.black;
            myRigidbody.velocity = new Vector2(0, 0);
            myRigidbody.rotation += 0.1f;
        }
        timer += Time.deltaTime;

       
        healthText.text = "Boss Health: " + health.ToString();
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Sword"))
            if (collision.gameObject.CompareTag("Sword"))
            {
                //if(FindObjectOfType<PlayerSwordAttack>().IsSwordCharged())
                if (collision.gameObject.GetComponent<PlayerSwordAttack>().IsSwordCharged())
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
