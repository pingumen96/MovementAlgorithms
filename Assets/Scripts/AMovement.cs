using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMovement : MonoBehaviour {
    public struct Steering {
        public Vector3 linear;
        public float angular;
    }

    protected float maxAcceleration = 3.0f;

    protected abstract void getSteering();
}
