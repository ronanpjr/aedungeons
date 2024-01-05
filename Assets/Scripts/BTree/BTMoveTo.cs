using System;
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
        if (Vector3.Distance(player.position, enemy.position) < 0.01f) {
            return Result.Success;
        }
        else {
            enemy.position = Vector3.MoveTowards(enemy.position, player.position, Tree.speed * Time.deltaTime);
            return Result.Failure;
        }
    }
}