using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : AgentBehaviour {
    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;

    public override Steering GetSteering() {
        Steering steering = new Steering();
        float targetOrientation = target.GetComponent<Agent>().orientation;
        float rotation = targetOrientation - agent.orientation;
        rotation = Utilities.Math.MapToRange(rotation);

        float rotationSize = Mathf.Abs(rotation);

        if(rotationSize < targetRadius) {
            return steering;
        }

        float targetRotation;

        if(rotationSize > slowRadius) {
            targetRotation = agent.maxRotation;
        } else {
            targetRotation = agent.maxRotation * rotationSize / slowRadius;
        }

        targetRotation *= rotation / rotationSize;
        steering.angular = (targetRotation - agent.rotation) / timeToTarget;

        float angularAcceleration = Mathf.Abs(steering.angular);
        if(angularAcceleration > agent.maxAngularAcceleration) {
            steering.angular /= angularAcceleration;
            steering.angular *= agent.maxAngularAcceleration;
        }
        return steering;
    }
}
