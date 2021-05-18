using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5.0f;

    Rigidbody2D _body;
    Vector2 direction = Vector2.up;

    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = _body.position;

        //rotates the player to face left or right
        if(direction.x != 0)
        {
            if(direction.x > 0f)
            {
                _body.SetRotation(270f);
            }
            else
            {
                _body.SetRotation(90f);
            }
        }

        //checks if facing up or down
        if (direction.y != 0)
        {
            if(direction.y >0)
            {
                _body.SetRotation(0f);
            }
            else
            {
                _body.SetRotation(180f);
            }
        }

        position.x += moveSpeed * direction.x * Time.deltaTime;
        position.y += moveSpeed * direction.y * Time.deltaTime;

        _body.MovePosition(position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Contains("Boss"))
        {
            FindObjectOfType<PlayerLife>().PlayerLifeDecrease();
        }
    }
}
