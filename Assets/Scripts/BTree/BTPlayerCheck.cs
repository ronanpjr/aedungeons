using System;
using UnityEngine;
public class BTPlayerCheck : BTNode 
{   

    public Transform player;
    public Transform enemy;
    public BTPlayerCheck(BehaviorTree bT, Transform p, Transform e) : base(bT) {
        player = p;
        enemy = e;
    }
 
    public override Result Execute() {
        if(Vector3.Distance(player.position, enemy.position) < 0.8f) {
            return Result.Success;
        }
        return Result.Failure;
    }
}   