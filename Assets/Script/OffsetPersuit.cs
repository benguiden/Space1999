using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OffsetPersuit : BoidBehaviour{

    #region Public Variables
    public Boid leader;
    public float cruiseSpeed;
    #endregion

    private Vector3 offset;

    public OffsetPersuit(Boid _boid) {
        boid = _boid;
    }

    public override void Awake() {
        if ((enabled) && (leader != null)) {
            offset = boid.transform.position - leader.transform.position;
            offset = Quaternion.Inverse(leader.transform.rotation) * offset;
        }
    }

    public override void Update() {
        if ((enabled) && (leader != null)) {
            Vector3 targetPosition = leader.transform.TransformPoint(offset);

            //Get Time to leader
            float timeToLeader = 0f;
            if (cruiseSpeed != 0f)
                timeToLeader = Vector3.Distance(leader.transform.position, boid.transform.position) / cruiseSpeed;

            //Get Predicted Position
            targetPosition += leader.velocity * timeToLeader;
            
            //Seek
            Vector3 difference = targetPosition - boid.transform.position;
            difference = difference.normalized * cruiseSpeed;
            float distance = Vector3.Distance(boid.transform.position, leader.transform.position);
            if (distance > offset.magnitude + 2f)
                difference *= 1.25f;
            else if (distance < offset.magnitude - 2f)
                difference *= 0.75f;
            Vector3 desiredAcceleration = difference - boid.velocity;
            boid.acceleration = desiredAcceleration;
        }
    }

}
