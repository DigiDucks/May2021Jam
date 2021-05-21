using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]
    bool damageOnCollision = false;
    [SerializeField]
    bool damageOnTrigger = false;
    [SerializeField]
    ParticleSystem _particles;

    float knockBack = 1.0f;

    private void Start()
    {
        ParticleSystem[] parsys = FindObjectsOfType<ParticleSystem>();
        foreach (ParticleSystem ps in parsys)
        {
            if(ps.gameObject.name.Contains("HurtEffect"))
            {
                _particles = ps;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageOnTrigger && collision.gameObject.GetComponent<PlayerLife>())
        {
            if (collision.gameObject.GetComponent<PlayerLife>().CanPlayerBeHit())
            {
                StartCoroutine(InvFrames(collision));
                PlayerLife pLife = collision.gameObject.GetComponent<PlayerLife>();
                pLife.PlayerLifeDecrease();
                _particles.gameObject.transform.position = collision.gameObject.transform.position;
                _particles.Play();

                Rigidbody2D pBody = pLife.gameObject.GetComponent<Rigidbody2D>();
                Vector2 difference = pBody.transform.position - transform.position;
                difference = difference.normalized * knockBack;
                pBody.position += difference;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageOnCollision && collision.gameObject.GetComponent<PlayerLife>())
        {
            if (collision.gameObject.GetComponent<PlayerLife>().CanPlayerBeHit())
            {
                StartCoroutine(InvFrames(collision));
                PlayerLife pLife = collision.gameObject.GetComponent<PlayerLife>();
                pLife.PlayerLifeDecrease();
                _particles.gameObject.transform.position = collision.gameObject.transform.position;
                _particles.Play();

                Rigidbody2D pBody = pLife.gameObject.GetComponent<Rigidbody2D>();
                Vector2 difference = pBody.transform.position - transform.position;
                difference = difference.normalized * knockBack;
                pBody.position += difference;
            }
        }
    }

    IEnumerator InvFrames(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerLife>().PlayerHitStat(false);
        yield return new WaitForSeconds(1.5f);
        collision.gameObject.GetComponent<PlayerLife>().PlayerHitStat(true);
    }

    IEnumerator InvFrames(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerLife>().PlayerHitStat(false);
        yield return new WaitForSeconds(1.5f);
        collision.gameObject.GetComponent<PlayerLife>().PlayerHitStat(true);
    }
}
