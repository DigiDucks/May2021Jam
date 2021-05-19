using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField]
    bool damageOnCollision = false;
    [SerializeField]
    bool damageOnTrigger = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageOnTrigger && collision.gameObject.GetComponent<PlayerLife>())
        {
            collision.gameObject.GetComponent<PlayerLife>().PlayerLifeDecrease();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageOnCollision && collision.gameObject.GetComponent<PlayerLife>())
        {
            collision.gameObject.GetComponent<PlayerLife>().PlayerLifeDecrease();
        }
    }
}
