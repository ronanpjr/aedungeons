using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


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
    
    [SerializeField] private HealthNode top;



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

    public bool PopArmor() {
       if(!Empty()) {
        if(top.healthType == false) {
            if(top.next == null) {
                top = null;
                Debug.Log("eu n aguento mais");
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
        // x = anterior.next.health;
        anterior.next = anterior.next.next;
        return true;
       }
       else return false;

           
    }

      public bool PopMR() {
       if(!Empty()) {
        if(top.healthType == true) {
            if(top.next == null) {
                top = null;
                Debug.Log("eu n aguento mais 2");
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
        Debug.Log(top.next);
        Debug.Log(top.health);
        Debug.Log(top.healthType);
        }
        else {
            Debug.Log("top is null");
        }
    }
}
}
