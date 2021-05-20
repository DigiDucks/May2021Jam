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

    private void Start()
    {
        ParticleSystem[] parsys = FindObjectsOfType<ParticleSystem>();
        _particles = parsys[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageOnTrigger && collision.gameObject.GetComponent<PlayerLife>())
        {
            if (collision.gameObject.GetComponent<PlayerLife>().CanPlayerBeHit())
            {
                StartCoroutine(InvFrames(collision));
                collision.gameObject.GetComponent<PlayerLife>().PlayerLifeDecrease();
                _particles.gameObject.transform.position = collision.gameObject.transform.position;
                _particles.Play();
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
                collision.gameObject.GetComponent<PlayerLife>().PlayerLifeDecrease();
                _particles.gameObject.transform.position = collision.gameObject.transform.position;
                _particles.Play();
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
