using System.Collections;
using System.Collections.Generic;
using Lista;
using Unity.VisualScripting;
using UnityEngine;
using Enemy;
using UnityEngine.SceneManagement;

class Boss : Inimigo {
    public override void Start() {  
        vidas = new HealthList();
        vidas.Push(5, false);
        vidas.Push(5, true);
    }

    public override void Death()
    {
        SceneManager.LoadScene(2);
        base.Death();
    }
}

