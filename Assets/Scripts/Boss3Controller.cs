using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss3Controller : MonoBehaviour
{
    private Rigidbody2D myRigidbody;// variable handles the rigid body of the enemy
    [SerializeField] int health = 100;          // Health of the boss
    [SerializeField] Text healthText;            // Text of the health
    [SerializeField] GameObject projectilePrefab; // prefab of the projectile the enemy shoots
    private float shotTimer = 0f;// start of timer before shooting the projectile
    [SerializeField] float shotTimerMax = 3f;// Max time before shooting the player
    [SerializeField] float projectileSpeed = 5f;//speed of the projectile fired

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
            Destroy(gameObject);
        }
        if (health <= 70 && health>=31)
        {
            Boss3BulletSpawner[] weapons = FindObjectsOfType<Boss3BulletSpawner>();
            for(int i = 0;i<weapons.Length;i++)
            {
                Destroy(weapons[i]);
            }
            shotTimer += Time.deltaTime;
            if (shotTimer > shotTimerMax)
            {
                PlayerMovement player = FindObjectOfType<PlayerMovement>();

                Vector2 direction = player.transform.position - transform.position;
                direction.Normalize();
                BossBullet proj = Instantiate(projectilePrefab, direction, Quaternion.identity).GetComponent<BossBullet>();
                Rigidbody2D rigidBodyBullet = proj.GetComponent<Rigidbody2D>();
                proj.transform.position = new Vector2(transform.position.x,transform.position.y+7.0f);
                proj.transform.localScale = proj.transform.localScale * 2;
                rigidBodyBullet.velocity = direction * projectileSpeed * 2;
                shotTimer = 0;
            }
        }
        if(health<= 30)
        {
            transform.position = new Vector2(transform.position.x,transform.position.y-0.001f);
            if(transform.position.y <= -4)
            {
                PlayerMovement player = FindObjectOfType<PlayerMovement>();
                Destroy(player);
            }
        }

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
