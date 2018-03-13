using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    #region Public Variables
    [Header("Physics")]
    public float mass = 1f;
    public float maxSpeed = 10f;
    [Range(0f, 1f)]
    public float drag = 0.05f;

    [Header("Behaviours")]
    public Seek seekBehaviour;

    [HideInInspector]
    public Vector3 velocity, acceleration;
    #endregion

    #region Mono Methods
    void Awake() {
        seekBehaviour.SetBoid(this);
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }

    void Update() {
        seekBehaviour.Update();
        UpdatePhysics();
    }
    #endregion

    void UpdatePhysics() {
        velocity += acceleration;
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        acceleration = Vector3.zero;

        //Update Forward

        transform.position += velocity * Time.deltaTime;
    }

}
