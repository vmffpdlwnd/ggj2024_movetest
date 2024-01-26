using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    Rigidbody2D rigid;

    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float speed;

    float jumpCount = 0;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount == 0)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0;
        }
    }
}
