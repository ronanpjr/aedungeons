using System;
using System.Numerics;
using UnityEngine;
public class BTMoveTo : BTNode 
{   

    public Transform player;
    public Transform enemy;
    public BTMoveTo(BehaviorTree bT, Transform p, Transform e) : base(bT) {
        player = p;
        enemy = e;
    }
 
    public override Result Execute() {
        if (UnityEngine.Vector3.Distance(player.position, enemy.position) <= 0.1f) {
            return Result.Success;
        }
        else if(UnityEngine.Vector3.Distance(player.position, enemy.position) <= 0.8f) {
            enemy.position = UnityEngine.Vector3.MoveTowards(enemy.position, player.position, Tree.speed * Time.deltaTime);
            return Result.Running;
        }
        return Result.Failure;
    }
}