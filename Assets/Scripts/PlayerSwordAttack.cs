using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    Collider2D _col;
    SpriteRenderer _rend;

    [SerializeField]
    bool canSwing = true;

    [SerializeField]
    float swingCooldown = 0.25f;

    void Start()
    {
        _col = GetComponent<Collider2D>();
        _rend = GetComponent<SpriteRenderer>();

        _col.enabled = false;
        _rend.enabled = false;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canSwing)
        {
            StartCoroutine("SwingSword");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {

        }
    }


    IEnumerator SwingSword()
    {
        _col.enabled = true;
        _rend.enabled = true;
        yield return new WaitForSeconds(swingCooldown);
        _col.enabled = false;
        _rend.enabled = false;
    }
}
