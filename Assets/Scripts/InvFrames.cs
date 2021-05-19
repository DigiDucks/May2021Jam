using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvFrames : MonoBehaviour
{
    float iFrameValue = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Color spriteColor = gameObject.GetComponent<SpriteRenderer>().color;
        if(!gameObject.GetComponentInParent<PlayerLife>().CanPlayerBeHit())
        {
            spriteColor.a = Mathf.Abs(Mathf.Sin(iFrameValue));
            gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
            iFrameValue += 0.05f;
        }
        else if(gameObject.GetComponent<SpriteRenderer>().color.a < 255.0f)
        {
            spriteColor.a = 255.0f;
            gameObject.GetComponent<SpriteRenderer>().color = spriteColor;
            iFrameValue = 0.0f;
        }
    }
}
