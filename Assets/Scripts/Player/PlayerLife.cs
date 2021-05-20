using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int health = 5;        // Health of player
    [SerializeField] Text healthText;       // Text of the health

    bool canBeHit = true;                   // Variable for I-Frames

    // Start is called before the first frame update
    void Start()
    {
        healthText.text = "HP: " + health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        healthText.text = "HP: " + health.ToString();
    }

    public void PlayerLifeDecrease()
    {
        health--;
    }

    public void PlayerHitStat(bool newStat)
    {
        canBeHit = newStat;
    }

    public bool CanPlayerBeHit()
    {
        return canBeHit;
    }
    public int PlayerGetLife()
    {
        return health;
    }
}
