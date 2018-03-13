using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {

    #region Public Variables
    [Header("Physics")]
    public float mass = 1f;
    public float maxSpeed = 10f;

    [HideInInspector]
    public Vector3 velocity, acceleration;
    #endregion

    #region Mono Methods
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }
    #endregion

}
