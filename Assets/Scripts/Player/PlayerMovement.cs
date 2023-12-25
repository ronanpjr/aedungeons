using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.6f;
    public Rigidbody2D rb;

    public Animator animator;
    private Vector2 moveDirection;

    public DirecaoMovimento direcaoMovimento;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        
        if (moveDirection.x > 0)
        {
            this.direcaoMovimento = DirecaoMovimento.Direita;
        }
        else if (moveDirection.x < 0){
            this.direcaoMovimento = DirecaoMovimento.Esquerda;
        }
       
    }

    private void Start(){
        this.direcaoMovimento = DirecaoMovimento.Direita;
    }
    void FixedUpdate() {

        Move();

    }


    
    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("horizontal", moveDirection.x);
        animator.SetFloat("vertical", moveDirection.y);
        animator.SetFloat("speed", moveDirection.sqrMagnitude);
        
    }

    void Move() {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

}
