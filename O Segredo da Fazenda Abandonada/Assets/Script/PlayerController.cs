using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Aqui fazemos a movimenta��o do personagem
    private Vector2 moveInput;
    // Aqui definimos a velocidade do personagem
    private float speed = 5f;

    //Aqui  definimos a dire��o em que o personagem est� indo
    private bool isFacingRight;
    private bool isFacingUp;
    private bool isFacingLeft;
    private bool isFacingDown;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aqui definimos a movimenta��o do personagem
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        if (moveInput.x == 0 && moveInput.y == 0)
        {
            // Aqui definimos a anima��o do personagem quando ele n�o est� se movendo
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
            if (isFacingRight)
            {
                animator.SetBool("isIdleFacingRight", true);
                animator.SetBool("isIdleFacingLeft", false);
                animator.SetBool("isIdleFacingUp", false);
                animator.SetBool("isIdleFacingDown", false);
            }
            else if (isFacingLeft)
            {
                animator.SetBool("isIdleFacingLeft", true);
                animator.SetBool("isIdleFacingUp", false);
                animator.SetBool("isIdleFacingRight", false);
                animator.SetBool("isIdleFacingDown", false);
            }
            else if (isFacingUp)
            {
                animator.SetBool("isIdleFacingUp", true);
                animator.SetBool("isIdleFacingDown", false);
                animator.SetBool("isIdleFacingLeft", false);
                animator.SetBool("isIdleFacingRight", false);
            }
            else if (isFacingDown)
            {               
                animator.SetBool("isIdleFacingDown", true);
                animator.SetBool("isIdleFacingUp", false);
                animator.SetBool("isIdleFacingLeft", false);
                animator.SetBool("isIdleFacingRight", false);
            }
        }
        else
        {
            // Aqui definimos a anima��o do personagem quando ele est� se movendo
            isFacingUp = false;
            isFacingDown = false;
            isFacingRight = false;
            isFacingLeft = false;
            animator.SetBool("isIdleFacingRight", false);
            animator.SetBool("isIdleFacingLeft", false);
            animator.SetBool("isIdleFacingUp", false);
            animator.SetBool("isIdleFacingDown", false);
        }
        if (moveInput.y > 0)
        {
            // Aqui definimos a anima��o do personagem quando ele se move para cima
            isFacingUp = true;
            isFacingDown = false;
            isFacingRight = false;
            isFacingLeft = false;
            animator.SetBool("isWalkingUp", true);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);
        }
        else if (moveInput.y < 0)
        {
            // Aqui definimos a anima��o do personagem quando ele se move para baixo
            isFacingUp = false;
            isFacingDown = true;
            isFacingRight = false;
            isFacingLeft = false;
            animator.SetBool("isWalkingDown", true);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
        }
        else if (moveInput.x > 0)
        {
            // Aqui definimos a anima��o do personagem quando ele se move para a direita
            isFacingUp = false;
            isFacingDown = false;
            isFacingRight = true;
            isFacingLeft = false;
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
        }
        else if (moveInput.x < 0)
        {
            // Aqui definimos a anima��o do personagem quando ele se move para a esquerda
            isFacingUp = false;
            isFacingDown = false;
            isFacingRight = false;
            isFacingLeft = true;
            animator.SetBool("isWalkingLeft", true);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
        }
    }
    void FixedUpdate()
    {
        // Calcula a nova posição do personagem
        rb.velocity = moveInput * speed;
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Espantalho"){
            Debug.Log("foi");
        }
        else if (collision.tag == "wall")
        {
            Debug.Log("foi");
        }

    }
}
