using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
  private float _delay = 5;

    public void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay -= Time.fixedDeltaTime;

            if (_delay <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}

