using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Lista;

public class HealthText : MonoBehaviour
{
    public TextMeshProUGUI   txt;
    public GameController gc;

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
        //gc.playerHealth.UIPrintFila();
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Q)) {  
            txt.text = gc.playerHealth.UIPrintFila();
        
        }
    }
}
