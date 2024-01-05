using System.Collections;
using System.Collections.Generic;
using Lista;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    [SerializeField]
    private int v;
    private bool t=false;
    private HealthList vidas;

    public void Start() {
        vidas = new HealthList(v, t);
    }

    public void receberDano (){
        this.vidas.top.health--;
        Debug.Log(this.name + " recebeu dano. Vida: " + this.vidas.top.health);
        if (this.vidas.top.health == 0)
        {   
            this.vidas.PopArmor();
        }
        if (this.vidas.top == null) {
            Destroy(gameObject);
        }   
        
    }
    
}
