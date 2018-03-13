using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Seek : BoidBehaviour {

    #region Public Variables
    public Vector3 targetPosition;
    public float cruiseSpeed = 10f;
    #endregion

    public Seek(Boid _boid){
        boid = _boid;
    }

    public override void Update() {
        if (enabled) {
            Vector3 difference = targetPosition - boid.transform.position;
            difference = difference.normalized * cruiseSpeed;
            Vector3 desiredAcceleration = difference - boid.velocity;
            boid.acceleration = desiredAcceleration;
        }
    }

}
