using System;
using System.Collections;
using System.Collections.Generic;
using Lista;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy {
public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int v;
    public bool t;

    [NonSerialized] public HealthList vidas;

    public virtual void Start() {
        vidas = new HealthList();
        vidas.Push(v,t);
    }


    public  void receberDano() {
        if(this.vidas.top.healthType == false) {
            this.vidas.top.health--;
            Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas.top.health);
            if (this.vidas.top.health <= 0)
            {   
                this.vidas.PopArmor();
            }
            if (this.vidas.top == null) {
                Death();
            }   
        }
    }

    public  void receberDanoMagico() {
        if(this.vidas.top.healthType == true) {
            this.vidas.top.health--;
            Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas.top.health);
            if (this.vidas.top.health <= 0)
            {   
                this.vidas.PopMR();
            }
            if (this.vidas.top == null) {
                Death();
            }   
        } 
    }
    public virtual void Death() {
        Destroy(gameObject);
    }
}
} 