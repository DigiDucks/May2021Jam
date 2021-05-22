using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBossJump : MonoBehaviour
{
    public float JumpBossJumpCooldown;
    public bool JumpBossIsOnGround;
    public bool JumpBossHasLanded;
    private Collider2D _collider;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
        _collider.enabled = true;
        JumpBossIsOnGround = true;
        JumpBossJumpCooldown = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (JumpBossIsOnGround && JumpBossJumpCooldown <= 0.0f)
        {
            JumpBossIsOnGround = false;
            _collider.enabled = false;
            _animator.SetTrigger("JumpBossJump");
            Debug.Log("Jumping...");
        } 
        else if (JumpBossIsOnGround)
            JumpBossJumpCooldown -= Time.deltaTime;

            /*
            //have the sprite's scale follow a parabolic trail getting larger then smaller
            height = (-(x * x)) + (2 * x); // y = -x^2 + 4x

            Vector3 newScale = _transform.localScale;
            
            _transform.localScale.Set(newScale.x + height, newScale.y + height, newScale.z);

            x += Time.deltaTime; 
            if (height <= 0)
            {
                JumpBossJumpCooldown = 1.5f;
                JumpBossHasLanded = true;
            }
             */
    }
}
