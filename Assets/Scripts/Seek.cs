using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : AgentBehaviour {
    public override Steering GetSteering() {
        Steering steering = new Steering();
        steering.linear = target.transform.position - transform.position;
        steering.linear.Normalize();
        steering.linear *= agent.maxAcceleration;
        return steering;
    }
}
