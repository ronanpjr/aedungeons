using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;


namespace Lista {

[Serializable]
public class HealthNode
{
    public int health;
    public bool healthType;
    public HealthNode next;
        
    
}

[Serializable]
public class HealthList
{
    
    [SerializeField] public HealthNode top;



    public HealthList() {
        top = null;
    }


    public bool Empty() {   
        if(top == null) return true;
        else return false;
    }

    public bool Push(int x, bool type) {
        HealthNode aux = new HealthNode();
        aux.health = x;
        aux.healthType = type;
        aux.next = top;
        top = aux;
        if (top != null) return true;

        return false;
    }
    // Armor, um dos tipos de dano/vida 
    public bool PopArmor() {
       if(!Empty()) {
        if(top.healthType == false) {
            if(top.next == null) {
                top = null;
                Debug.Log("top is null armor");
                return true;
            }
            // x = top.health;
            top = top.next;
            return true;
        }
        HealthNode anterior = top;
        while(anterior.next != null  &&  anterior.next.healthType != false ) {
            anterior = anterior.next;
        }
        if(anterior.next == null) {
            return false;
        }
    
        anterior.next = anterior.next.next;
        return true;
       }
       else return false;

           
    }
    // MR = Magic Resistance - um dos tipos de dano/vida
      public bool PopMR() {
       if(!Empty()) {
        if(top.healthType == true) {
            if(top.next == null) {
                top = null;
                Debug.Log("top null funçao MR");
                return true;
            }
            // x = top.health;
            top = top.next;
            return true;
        }
        HealthNode anterior = top;
        while(anterior.next != null && anterior.next.healthType != true) {
            anterior = anterior.next;
        }
        if(anterior.next == null) {
            return false;
        }
        // x = anterior.next.health;
        anterior.next = anterior.next.next;
        return true;
       }
       
       else return false;

           
    }
    public void Display() {
        if (top != null) {
        Debug.Log(top);
        Debug.Log(top.health);
        Debug.Log(top.healthType);
        }
        else {
            Debug.Log("top is null");
        }
    }

    
    public string UIPrintFila() {
        if (Empty()) return "No life";
        else {
        HealthNode anterior = top;
        string healthStr = "Nodes de vida: ";
           while(anterior != null) {
            healthStr = healthStr + anterior.health.ToString();
            if (anterior.healthType == false) {
                healthStr = healthStr + " de Armadura" + "   ";
            }
            else {
                 healthStr = healthStr + " de Resistencia Magica" + "   ";
            }
            anterior = anterior.next;
            }
        return healthStr;
        }
    }
}
    
}
