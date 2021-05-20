using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordAttack : MonoBehaviour
{
    int swordCharge = 0;
    bool isCharged = false;

    [SerializeField]
    GameObject _parsys;

    Collider2D _col;
    SpriteRenderer _rend;
    Animator _anim;
    
    PlayerPowerManager power;
    PlayerSwordSounds swordSounds;  // Script for sound effects

    [SerializeField]
    bool canSwing = true;

    bool canCharge = true;

    //[SerializeField]
    //float swingCooldown = 0.25f;

    void Start()
    {
        _col = GetComponent<Collider2D>();
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        power = GetComponentInParent<PlayerPowerManager>();
        swordSounds = GetComponentInParent<PlayerSwordSounds>();

        _col.enabled = false;
        _rend.enabled = false;
    }

    void Update()
    {
        if((Input.GetButtonDown("Fire1")||Input.GetKeyDown("space")) && canSwing)
        {
            if(canSwing)
            {
                StartCoroutine("SwingSword");
            }
        }
        if ((Input.GetButton("Fire1") || Input.GetKey("space")) && power.CheckPower() >= 3.0f && canCharge)
        {
            if(_parsys.activeSelf == false)
            {
                _parsys.SetActive(true);
                swordSounds.PlayChargeUp(); // Charge up sound effect
            }
            if(swordCharge < 180)
            {
                swordCharge++;
               // Debug.Log("Charging... " + swordCharge);
            }
            else
            {
                Debug.Log("Charged");
            }
        }
        if((Input.GetButtonUp("Fire1") || Input.GetKeyUp("space")) && swordCharge == 180)
        {
            _parsys.SetActive(false);
            swordSounds.StopChargeUp(); // End charge up sound effect

            StartCoroutine("ChargedSwing");
            swordCharge = 0;
            power.AddPower(-3.0f);
            Debug.Log("Attacked");
        }
        else if((Input.GetButtonUp("Fire1") || Input.GetKeyUp("space")))
        {
            _parsys.SetActive(false);
            swordSounds.StopChargeUp(); // End charge up sound effect
            swordCharge = 0;
            Debug.Log("Charge Lost");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isCharged)
        {
            power.AddPower(1.0f);
        }
    }

    public bool IsSwordCharged()
    {
        return isCharged;
    }

    IEnumerator ChargedSwing()
    {
        isCharged = true;
        canCharge = false;

        swordSounds.PlaySwingCharged(); // Sound effect

        _anim.SetTrigger("ChargeSwing");
        yield return new WaitForSeconds(0.6f);
        canCharge = true;
        isCharged = false;
    }

    IEnumerator SwingSword()
    {
        swordSounds.PlaySwingRegular(); // Sound effect

        _anim.SetTrigger("SwingSword");
        canSwing = false;
        yield return new WaitForSeconds(0.5f);
        canSwing = true;
    }
}
