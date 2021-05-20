using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss4Sword : MonoBehaviour
{
    Collider2D col;
    SpriteRenderer rend;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        col.enabled = false;
        rend.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void Swing()
    {
        StartCoroutine("SwingSword");
    }
    public void Idle()
    {
        anim.SetTrigger("IdleSword");
        anim.ResetTrigger("SwingSword");
        Debug.Log("Stop");
    }
    public void Slow()
    {
        StartCoroutine("SlowSwing");
    }
    public IEnumerator SwingSword()
    {
        anim.SetTrigger("SwingSword");
        yield return new WaitForSeconds(0.5f);
        //anim.SetTrigger("SwingSword");
    }
    public IEnumerator SlowSwing()
    {
        anim.SetTrigger("SlowSwing");
        yield return new WaitForSeconds(0.5f);
    }
}
