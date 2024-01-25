using System;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Enemy;
public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private Transform pontoAtaqueDireita, pontoAtaqueEsquerda;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask layerAtaque;

    [SerializeField]
    private PlayerMovement jogador;

    public GameObject arrowPrefab;
     public Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Z))
        {
            Atacar();
        }


        if(Input.GetButtonDown("Fire2") || Input.GetKeyDown(KeyCode.X)) {
            
            UnityEngine.Vector2 direcaoProjetil = new UnityEngine.Vector2(animator.GetFloat("lastmoveX"), animator.GetFloat("lastmoveY"));
            direcaoProjetil.Normalize();
            GameObject arrow = Instantiate(arrowPrefab, transform.position, UnityEngine.Quaternion.identity);    
            arrow.GetComponent<Rigidbody2D>().velocity = direcaoProjetil;   
            Atirar(arrow);
            Destroy(arrow, 3);
        }
        
        
    }


    private void OnDrawGizmos()
    {
        if (this.pontoAtaqueDireita != null)
        {
            // Desenha um circulo (na aba cena), serve pra visualizar o raio/ponto de ataque
            Gizmos.DrawWireSphere(this.pontoAtaqueDireita.position, this.raioAtaque);
        }
        if (this.pontoAtaqueEsquerda != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaqueEsquerda.position, this.raioAtaque);
        }
    }

    private void Atacar()
    {
        Transform pontoAtaque;
        animator.SetTrigger("attacking");
        FindObjectOfType<AudioManager>().Play("sword");
        if (this.jogador.direcaoMovimento == DirecaoMovimento.Direita)
        {
            pontoAtaque = this.pontoAtaqueDireita;
        }
        else
        {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }


        // Cria um circulo imaginario e verifica se tem algum objeto com colisor dentro da região (no caso: inimigo) 
        // Se tem algum objeto, ele o retorna
        Collider2D colliderInimigo = Physics2D.OverlapCircle(pontoAtaque.position, this.raioAtaque, this.layerAtaque);

        if (colliderInimigo != null)
        {
            Debug.Log("atacando inimigo" + colliderInimigo.name);
            // Buscando script do inimgo que esteja no mesmo objeto q o collider
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();

            if (inimigo != null)
            {
                inimigo.receberDano();
            }
        }
    }
    
    private void Atirar(GameObject arrow) {
        
        Collider2D colliderInimigo = Physics2D.OverlapCircle(arrow.transform.position, this.raioAtaque, this.layerAtaque);
        FindObjectOfType<AudioManager>().Play("fireball");

        if (colliderInimigo != null)
        {
            Debug.Log("atacando inimigo" + colliderInimigo.name);
            // Buscando script do inimgo que esteja no mesmo objeto q o collider
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
            
            if (inimigo != null)
            {
                
                inimigo.receberDanoMagico();
            }
            Destroy(arrow);
        }
    } 


}
