using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss1Controller : MonoBehaviour
{
    private Rigidbody2D myRigidbody;            // Rigidbody of the enemy
    [SerializeField] int health = 100;          // Health of the boss
    [SerializeField]Text healthText;            // Text of the health
    [SerializeField] ParticleSystem _particles; // Boss Destroy Effect

    int phase;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        healthText.text = "Boss Health: " + health.ToString();
        phase = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(health <= 0)
        {
            _particles.transform.position = gameObject.transform.position;
            _particles.Play();
            GameManager gm = FindObjectOfType<GameManager>();
            gm.OpenWin();
            Destroy(gameObject);
        }
        if(health <= 50)
        {
            myRigidbody.rotation += 0.3f;
        }

        healthText.text = "Boss Health: " + health.ToString();
        StartCoroutine(PhaseChange());
        if (phase == 0)
        {
            BossRotate[] weapons = FindObjectsOfType<BossRotate>();
            weapons[0].Reverse();
            weapons[1].Reverse();
            //FindObjectOfType<BossRotate>().Reverse();
        }
        if (phase == 1)
        {
            BossRotate[] weapons = FindObjectsOfType<BossRotate>();
            weapons[0].Rotate();
            weapons[1].Rotate();
            //FindObjectOfType<BossRotate>().Rotate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            StartCoroutine(HitFlash());
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
    IEnumerator PhaseChange()
    {
        //yield return new WaitForSeconds(6f);
        //phase = 1;
        //yield return new WaitForSeconds(6f);
        //phase = 0;
        //yield return new WaitForSeconds(6f);
        //phase  = 1
        for(int i= 0; i<12;i++)
        {
            //yield return new WaitForSeconds(6f);
            //if (phase == 1)
            //{
            //    phase = 0;
            //} else
            //{
            //    phase = 1;
            //}
            yield return new WaitForSeconds(4f);
            phase = 1;
            yield return new WaitForSeconds(4f);
            phase = 0;
            yield return new WaitForSeconds(4f);
            phase = 1;
            yield return new WaitForSeconds(4f);

        }
    }

    IEnumerator HitFlash()
    {
        Color bossColor = gameObject.GetComponent<SpriteRenderer>().color;
        bossColor.r = 0.5f;
        gameObject.GetComponent<SpriteRenderer>().color = bossColor;
        yield return new WaitForSeconds(0.4f);
        bossColor.r = 1.0f;
        gameObject.GetComponent<SpriteRenderer>().color = bossColor;
    }
}
