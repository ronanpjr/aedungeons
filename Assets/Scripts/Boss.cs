using System.Collections;
using System.Collections.Generic;
using Lista;
using Unity.VisualScripting;
using UnityEngine;
using Enemy;

class Boss : Inimigo {
    public override void Start() {  
        vidas = new HealthList();
        vidas.Push(5, false);
        vidas.Push(5, true);
    }

}

    