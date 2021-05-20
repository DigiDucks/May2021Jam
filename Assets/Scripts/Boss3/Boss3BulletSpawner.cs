using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3BulletSpawner : MonoBehaviour
{
    private Rigidbody2D myRigidbody;// variable handles the rigid body of the enemy
    [SerializeField] GameObject projectilePrefab; // prefab of the projectile the enemy shoots
    private float shotTimer = 0f;// start of timer before shooting the projectile
    [SerializeField] float shotTimerMax = 3f;// Max time before shooting the player
    [SerializeField] float projectileSpeed = 3f;//speed of the projectile fired

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > shotTimerMax)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();

            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            BossBullet proj = Instantiate(projectilePrefab, direction, Quaternion.identity).GetComponent<BossBullet>();
            Rigidbody2D rigidBodyBullet = proj.GetComponent<Rigidbody2D>();
            proj.transform.position = transform.position;
            rigidBodyBullet.velocity = direction * projectileSpeed * 2;
            shotTimer = 0;
        }
    }
}
