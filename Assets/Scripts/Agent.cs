using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public float maxSpeed;
    public float maxAcceleration;
    public float maxRotation; // rappresenta in qualche modo un attrito angolare
    public float maxAngularAcceleration;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;

	// Use this for initialization
	void Start () {
        velocity = Vector3.zero;
        steering = new Steering();
	}

    public void SetSteering(Steering steering) {
        this.steering = steering;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        Vector3 displacement = velocity * Time.deltaTime;
        orientation += rotation * Time.deltaTime;

        // i valori di orientation devono rientrare nel range 0 - 360
        if(orientation < 0.0f) {
            orientation += 360.0f;
        } else if(orientation > 360.0f) {
            orientation -= 360.0f;
        }

        transform.Translate(displacement, Space.World);
        transform.rotation = new Quaternion();
        transform.Rotate(Vector3.up, orientation);
	}

    // calcoliamo lo steering per il prossimo frame
    public virtual void LateUpdate() {
        velocity += steering.linear * Time.deltaTime;
        rotation += steering.angular * Time.deltaTime;

        if(velocity.magnitude > maxSpeed) {
            velocity.Normalize();
            velocity *= maxSpeed;
        }

        if(steering.angular == 0.0f) {
            rotation = 0.0f;
        }

        if(steering.linear.sqrMagnitude == 0.0f) {
            velocity = Vector3.zero;
        }

        steering = new Steering();
    }
}
