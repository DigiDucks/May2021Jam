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

    [SerializeField]
    bool canSwing = true;

    //[SerializeField]
    //float swingCooldown = 0.25f;

    void Start()
    {
        _col = GetComponent<Collider2D>();
        _rend = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
        power = GetComponentInParent<PlayerPowerManager>();

        _col.enabled = false;
        _rend.enabled = false;
    }

    void Update()
    {
        if((Input.GetButtonDown("Fire1")||Input.GetKeyDown("space")) && canSwing)
        {
            _anim.SetTrigger("SwingSword");
        }
        if ((Input.GetButton("Fire1") || Input.GetKey("space")) && power.CheckPower() >= 3.0f)
        {
            if(_parsys.activeSelf == false)
            {
                _parsys.SetActive(true);
            }
            if(swordCharge < 250)
            {
                swordCharge++;
                Debug.Log("Charging... " + swordCharge);
            }
            else
            {
                Debug.Log("Charged");
            }
        }
        if((Input.GetButtonUp("Fire1") || Input.GetKeyUp("space")) && swordCharge == 250)
        {
            _parsys.SetActive(false);
            StartCoroutine("ChargedSwing");
            swordCharge = 0;
            power.AddPower(-3.0f);
            Debug.Log("Attacked");
        }
        else if((Input.GetButtonUp("Fire1") || Input.GetKeyUp("space")))
        {
            _parsys.SetActive(false);
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
        _anim.SetTrigger("ChargeSwing");
        yield return new WaitForSeconds(0.6f);
        isCharged = false;
    }

    //IEnumerator SwingSword()
    //{
    //    _col.enabled = true;
    //    _rend.enabled = true;
    //    yield return new WaitForSeconds(swingCooldown);
    //    _col.enabled = false;
    //    _rend.enabled = false;
    //}
}
