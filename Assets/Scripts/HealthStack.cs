using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Pilha {

[Serializable]
public class HealthNode
{
    public int health;
    public bool healthType;
    public  HealthNode next;
        
    
}

[Serializable]
public class HealthStack
    {
    
    [SerializeField] private HealthNode top;



    public HealthStack() {
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

    public bool Pop(ref int x) {
       if(!Empty()) {
         x = top.health;
        top = top.next;
        return true;
       }
       else return false;

           
    }
    public void Display() {
        Debug.Log(top.health);
        Debug.Log(top.healthType);
        Debug.Log(top.next);
    }
}
}
