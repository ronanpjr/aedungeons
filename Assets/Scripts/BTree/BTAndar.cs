using System;
using UnityEngine;
public class BTAndar : BTNode 
{   
    public Transform transform; // corpo do inimigo e coisa
    public Transform [] waypoints;
    public int currentWaypoint = 0;

    public float waitTime = 1.5f;
    public float waitCounter = 0;
    public bool waiting = false;
    public BTAndar(BehaviorTree bT, Transform t, Transform [] w) : base(bT) {
        transform = t; 
        waypoints = w; 
    }
 
   
    
    public override Result Execute() {
        if (waiting) {
            waitCounter += Time.deltaTime;
            if (waitCounter >= waitTime) {
                waiting = false;
            }
        }
        else {
            Transform wp = waypoints[currentWaypoint];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f) {
                transform.position = wp.position;
                waitCounter = 0f;
                waiting = true;
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                return Result.Success;
            }
            else {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, Tree.speed * Time.deltaTime);
                return Result.Running;
            }
        }
        return Result.Success;
    }
}