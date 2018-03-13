using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    #region Public Variables
    [Header("Physics")]
    public float mass = 1f;
    public float maxSpeed = 10f;

    [Header("Behaviours")]
    public Seek seekBehaviour;
    public OffsetPersuit persuitBehaviour;

    [HideInInspector]
    public Vector3 velocity, acceleration;
    #endregion

    private Vector3 desiredForward;

    #region Mono Methods
    void Awake() {
        seekBehaviour.SetBoid(this);
        persuitBehaviour.SetBoid(this);
        desiredForward = transform.forward;
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }

    void Update() {
        seekBehaviour.Update();
        persuitBehaviour.Update();
        UpdatePhysics();
    }
    #endregion

    void UpdatePhysics() {
        velocity += acceleration;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        acceleration = Vector3.zero;

        desiredForward = Vector3.Lerp(desiredForward, velocity, 0.25f);
        transform.forward = desiredForward;

        transform.position += velocity * Time.deltaTime;
    }

}
