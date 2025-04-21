using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float MoveX;
    private float MoveY;
    private float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(MoveX * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, MoveY * speed);
    }
}
