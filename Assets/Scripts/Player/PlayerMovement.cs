using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lista;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.6f;
    public Rigidbody2D rb;

    public Animator animator;
    private Vector2 moveDirection;

    public DirecaoMovimento direcaoMovimento;

    public GameController gc;

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

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1) {
            animator.SetFloat("lastmoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastmoveY", Input.GetAxisRaw("Vertical"));
        }
       
    }

    private void Start(){
        this.direcaoMovimento = DirecaoMovimento.Direita;
    }
    void FixedUpdate() {

        Move();
        PlayerStatus();
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Slime")
        {
            Debug.Log("PLAYER LEVANDO DANO");
            HealthNode atual  = gc.playerHealth.top;

            while(atual.next != null && atual.healthType != true) {
            atual = atual.next;
        }
            if(atual.healthType == true) {  
                atual.health--;
                if(atual.health <= 0) {
                    gc.playerHealth.PopMR();
                } 
            }
        }

        if(other.gameObject.tag == ("Bat")) 
        {

            Debug.Log("PLAYER LEVANDO DANO");
            HealthNode atual  = gc.playerHealth.top;

            while(atual.next != null && atual.healthType != false) {
            atual = atual.next;
            }

            if(atual.healthType == false) {  
                atual.health = atual.health - 2;
                if(atual.health <= 0) {
                    gc.playerHealth.PopArmor();
                } 
            }
        }
    }
    
    private void PlayerStatus() {
        if (gc.playerHealth.top == null)  Destroy(gameObject);
    }
}
