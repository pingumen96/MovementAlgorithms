using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour {
    public GameObject target;
    protected Agent agent;

    public float maxSpeed;
    public float maxAcceleration;
    public float maxRotation;
    public float maxAngularAcceleration;

    public virtual void Awake() {
        agent = gameObject.GetComponent<Agent>();
    }

    public virtual void Update() {
        agent.SetSteering(GetSteering());
    }

    public virtual Steering GetSteering() {
        return new Steering();
    }

}
