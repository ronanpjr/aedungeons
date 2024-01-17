using System.Collections;
using System.Collections.Generic;
using Lista;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int v;
    public bool t;

    private HealthList vidas;

    public void Start() {
        vidas = new HealthList();
        vidas.Push(v,t);
    }
    public void receberDano() {
        if(this.vidas.top.healthType == false) {
            this.vidas.top.health--;
            Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas.top.health);
            if (this.vidas.top.health <= 0)
            {   
                this.vidas.PopArmor();
            }
            if (this.vidas.top == null) {
                Destroy(gameObject);
            }   
        }
    }

    public void receberDanoMagico() {
        if(this.vidas.top.healthType == true) {
            this.vidas.top.health--;
            Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas.top.health);
            if (this.vidas.top.health <= 0)
            {   
                this.vidas.PopMR();
            }
            if (this.vidas.top == null) {
                Destroy(gameObject);
            }   
        } 
    }
}
