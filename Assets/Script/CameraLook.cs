using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour {

    public Transform target;
    [Range(float.Epsilon, 1f)]
    public float cameraSmoothness = 0.85f;

    private Vector3 targetPosition;

    void Update() {
        if (target!= null) {
            targetPosition = Vector3.Lerp(targetPosition, target.position, 1f - cameraSmoothness);
            transform.LookAt(targetPosition);
        }
    }
}
