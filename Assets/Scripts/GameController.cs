using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lista;
public class GameController : MonoBehaviour
{
 // Start is called before the first frame update
    public HealthList playerHealth = new HealthList();
    void Update()
    {   
        
        TestePilha();

    }
    
    // Update is called once per frame
    void TestePilha() {
        if(Input.GetKeyDown(KeyCode.F)) {
            int x = 10;
            bool type = false;
            playerHealth.Push(x, type);
        }

        if(Input.GetKeyDown(KeyCode.V)) {
            int x = 5;
            bool type = true;
            playerHealth.Push(x, type);

        }   

        if(Input.GetKeyDown(KeyCode.B)) {
            int x = 15;
            bool type = true;
            playerHealth.Push(x, type);

        }

        if(Input.GetKeyDown(KeyCode.J)) {
            playerHealth.Display();
        }
       
        if(Input.GetKeyDown(KeyCode.G)) {
            playerHealth.PopArmor();

        }   
    
        
        if(Input.GetKeyDown(KeyCode.H)) {            
            
            Debug.Log(playerHealth.PopMR());
        }       
    }

}
