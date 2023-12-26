using System;
using UnityEngine;

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


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atacar();
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
}
