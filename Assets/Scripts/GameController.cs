using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lista;

public class GameController : MonoBehaviour
{
 // Start is called before the first frame update
    HealthList playerHealth = new HealthList();
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
        }

        if(Input.GetKey(KeyCode.V)) {
            int x = 5;
            bool type = true;
            playerHealth.Push(x, type);

        }   

        
        if(Input.GetKey(KeyCode.B)) {
            int x = 15;
            bool type = true;
            playerHealth.Push(x, type);

        }

        if(Input.GetKey(KeyCode.J)) {
            playerHealth.Display();
        }
       
        if(Input.GetKey(KeyCode.G)) {
            playerHealth.PopArmor();

        }   
    
        
        if(Input.GetKey(KeyCode.H)) {            
            
            Debug.Log(playerHealth.PopMR());
        }       
    }
}

    