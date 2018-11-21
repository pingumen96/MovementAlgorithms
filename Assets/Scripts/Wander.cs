using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : Face {
    public float offset;
    public float radius;
    public float rate;

    public override void Awake() {
        target = new GameObject();
        target.transform.position = transform.position;
        base.Awake();
    }

    public override Steering GetSteering() {
        Steering steering = new Steering();
        float wanderOrientation = Random.Range(-1.0f, 1.0f) * rate;
        float targetOrientation = wanderOrientation + agent.orientation;
        Vector3 orientationVector = Utilities.Math.GetOrientationAsVector(agent.orientation);
        Vector3 targetPosition = (offset * orientationVector) + transform.position;
        targetPosition += Utilities.Math.GetOrientationAsVector(targetOrientation) * radius;
        targetAux.transform.position = targetPosition;
        steering = base.GetSteering();
        steering.linear = targetAux.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear *= agent.maxAcceleration;
        return steering;
    }
}
