using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereYoureGoing : Align {
    public override void Awake() {
        base.Awake();
        target = new GameObject();
        target.AddComponent<Agent>();
    }

    void OnDestroy() {
        Destroy(target);
    }

    public override Steering GetSteering() {
        if(agent.velocity.magnitude == 0.0f) {
            return new Steering();
        }

        float targetOrientation = Mathf.Atan2(agent.velocity.x, agent.velocity.z);
        targetOrientation *= Mathf.Rad2Deg;
        target.GetComponent<Agent>().orientation = targetOrientation;

        return base.GetSteering();
    }
}
