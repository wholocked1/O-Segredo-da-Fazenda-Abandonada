using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    // Aqui fazemos a movimentação do personagem
    private float MoveX;
    private float MoveY;
    // Aqui definimos a velocidade do personagem
    private float speed = 5f;

    //Aqui  definimos a direção em que o personagem está indo
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
        // Aqui definimos a movimentação do personagem
        MoveX = Input.GetAxisRaw("Horizontal");
        MoveY = Input.GetAxisRaw("Vertical");
        // Aqui definimos a velocidade do personagem na direção que ele está indo em X e Y
        rb.velocity = new Vector2(MoveX * speed, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, MoveY * speed); 

        //if (MoveX == 0 && MoveY == 0)
        //{
        //    // Aqui definimos a animação do personagem quando ele não está se movendo
        //    animator.SetBool("isWalkingRight", false);
        //    animator.SetBool("isWalkingLeft", false);
        //    animator.SetBool("isWalkingUp", false);
        //    animator.SetBool("isWalkingDown", false);
        //    if (isFacingRight)
        //    {
        //        animator.SetBool("isIdleRight", true);
        //    }
        //    else if (isFacingLeft)
        //    {
        //        animator.SetBool("isIdleLeft", true);
        //    }
        //    else if (isFacingUp)
        //    {
        //        animator.SetBool("isIdleUp", true);
        //    }
        //    else if (isFacingDown)
        //    {
        //        animator.SetBool("isIdleDown", true);
        //    }
        //}
        if (MoveY > 0)
        {
            // Aqui definimos a animação do personagem quando ele se move para cima
            isFacingUp = true;
            isFacingDown = false;
            isFacingRight = false;
            isFacingLeft = false;
            animator.SetBool("isWalkingUp", true);
            animator.SetBool("isWalkingDown", false);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingRight", false);
        }
        else if (MoveY < 0)
        {
            // Aqui definimos a animação do personagem quando ele se move para baixo
            isFacingUp = false;
            isFacingDown = true;
            isFacingRight = false;
            isFacingLeft = false;
            animator.SetBool("isWalkingDown", true);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingRight", false);
            animator.SetBool("isWalkingLeft", false);
        }
        else if (MoveX > 0)
        {
            // Aqui definimos a animação do personagem quando ele se move para a direita
            isFacingUp = false;
            isFacingDown = false;
            isFacingRight = true;
            isFacingLeft = false;
            animator.SetBool("isWalkingRight", true);
            animator.SetBool("isWalkingLeft", false);
            animator.SetBool("isWalkingUp", false);
            animator.SetBool("isWalkingDown", false);
        }
        else if (MoveX < 0)
        {
            // Aqui definimos a animação do personagem quando ele se move para a esquerda
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
}
