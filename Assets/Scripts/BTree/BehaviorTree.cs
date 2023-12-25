using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{
    private BTNode mRoot;
    private bool startedBehavior;
    private Coroutine behavior;

    public Dictionary<string, object> Blackboard {get; set;}
    public BTNode Root { get { return mRoot; } }



    // Start is called before the first frame update
    void Start()
    {
        Blackboard = new Dictionary<string, object>();
        Blackboard.Add("WorldBounds", new Rect(0,0,0.5f,0.5f));

        // comportamento inicial = parado;
        startedBehavior = false;
        mRoot =  new BTRepeater(this, new BTSequencer(this, 
                 new BTNode [] {new BTAndar(this)}));
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!startedBehavior) {
            behavior = StartCoroutine(RunBehavior());
            startedBehavior = true;
        }
    }

    private IEnumerator RunBehavior() {
        BTNode.Result result = Root.Execute();
        while (result == BTNode.Result.Running) {
            Debug.Log("resultado do Root: " + result);
            yield return null;
            result = Root.Execute();

        }
        Debug.Log("Comportamento terminou com: " + result);

    }
}
