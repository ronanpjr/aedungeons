using System;
using UnityEngine;
public class BTAttack : BTNode 
{   
    public GameController gc;
    public Transform player;
    public Transform enemy;
    public BTAttack(BehaviorTree bT, Transform p, Transform e, GameController gamecontroller) : base(bT) {
        player = p;
        enemy = e;
        gc = gamecontroller;
    }
 
    public override Result Execute() {
        if (gc.playerHealth.top == null) {
            return Result.Success;
        }
        else if(Vector3.Distance(player.position, enemy.position) <= 0.2f) {
            return Result.Running;
        }
        return Result.Failure;
    }
}