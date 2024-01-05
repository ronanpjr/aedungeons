using System; 
using System.Collections.Generic;
public class BTSelector : BTComposite 
{       
    private int currentNode = 0; 

    public BTSelector(BehaviorTree t, BTNode [] children): base(t, children) {
    }

    public override Result Execute() {
            if (currentNode < Children.Count) {
                Result result = Children[currentNode].Execute();
                
                if (result == Result.Running)
                    return Result.Running;
                else if (result == Result.Failure) {
                    currentNode++;
                    return Result.Running;
                }
                else {
                    currentNode++;
                    if (result == Result.Success)
                        return Result.Success;
                }
            }
            currentNode = 0;
            return Result.Failure;  
    }
}