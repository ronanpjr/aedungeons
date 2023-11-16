using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pilha;

public class GameController : MonoBehaviour
{
 // Start is called before the first frame update
    HealthStack playerHealth = new HealthStack();
    void Update()
    {   
        
        TestePilha();

    }

    // Update is called once per frame
    void TestePilha() {
        if(Input.GetKey(KeyCode.F)) {
                int x = 10;
                bool type = false;
                playerHealth.Push(x, type);
                playerHealth.Display();
        }
       
        if(Input.GetKey(KeyCode.G)) {
                int x = 0;
                playerHealth.Pop(ref x);
                playerHealth.Display();
        }   
    }
}
    