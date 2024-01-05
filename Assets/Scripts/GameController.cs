using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lista;
using System;
using System.Numerics;
using TMPro;


[Serializable]
public class GameController : MonoBehaviour
{
 // Start is called before the first frame update
    [SerializeField] private Transform trans; 
    [SerializeField] private Transform healingArea0;
    
    public TextMeshProUGUI   txt;

    private int nodeCount=0;
    public  HealthList playerHealth = new HealthList();
    
    void Start() {
        playerHealth.Push(5, true);
        playerHealth.Push(5, false);
    }

    void Update()
    {   
        txt.text = playerHealth.UIPrintFila();
        TestePilha();

    }
    
    // Update is called once per frame
    void TestePilha() {
        if(UnityEngine.Vector3.Distance(trans.position, healingArea0.position) < 0.1f) {
            if(nodeCount < 2) {
                int x = 5;
                bool type = false;
                playerHealth.Push(x, type);
                nodeCount++;
            }
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
   
        }       
   }



}

