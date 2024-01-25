using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lista;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 0.6f;
    public Rigidbody2D rb;

    public Animator animator;
    public Vector2 moveDirection;

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
        playerStatus();
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


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Slime"))
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

        if(other.gameObject.CompareTag(("Bat"))) 
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

        if (other.gameObject.CompareTag("Potion")) {
            gc.playerHealth.Push(5, false);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("LevelExit")) {
           this.transform.position = new Vector2(1.414f, 1.975f); 
        }

        if (other.gameObject.CompareTag("Return")) {
            this.transform.position = new Vector2(-0.55f, 0f);
        }
        if (other.gameObject.CompareTag("Stairs0")) {
            this.transform.position = new Vector2(-2.322f, 1.646f);
        }
               
    }
    
    void playerStatus() {
           if (gc.playerHealth.Empty()) SceneManager.LoadScene(1);
    }
}
