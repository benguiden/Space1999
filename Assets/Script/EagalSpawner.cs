﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagalSpawner : MonoBehaviour {

    #region Public Variables
    [Header("Spawning")]
    public float gap = 20f;
    public uint followers = 2;
    public GameObject prefab;
    #endregion

    private Boid spawnedLeader;

    #region Mono Methods
    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * 2f));
    }

    void Awake() {
        if (prefab != null)
            SpawnEagals();
    }
    #endregion

    #region Spawning Methods
    void SpawnEagals() {
        //Spawn Leader
        SpawnEagal(transform.position);

        for (int j = -1; j<= 1; j += 2) { //For lop for left and right side
            for (int i=1; i<=(int)followers; i++) {
                float currentGap = gap * i;
                Vector3 eagalPosition = transform.TransformPoint(new Vector3(currentGap * j, 0f, -currentGap));

                SpawnEagal(eagalPosition);
            }
        }
    }

    void SpawnEagal(Vector3 spawnPosition) {
        Transform eagalTransform = GameObject.Instantiate(prefab).transform;

        eagalTransform.position = spawnPosition;
        eagalTransform.forward = transform.forward;

        Boid eagalBoid = eagalTransform.GetComponent<Boid>();
        if (eagalBoid == null) {
            Debug.LogWarning("Warning: Spawning Eagal with no Boid component.");
            return;
        }

        //Set Leader if none exists
        if (spawnedLeader == null) {
            spawnedLeader = eagalBoid;
            eagalBoid.seekBehaviour.enabled = true;
            eagalBoid.seekBehaviour.targetPosition = spawnPosition + (transform.forward * 1000f);
            eagalBoid.seekBehaviour.Awake();

            eagalBoid.persuitBehaviour.enabled = false;

            //Set Camera Follow
            Camera.main.GetComponent<CameraLook>().target = eagalTransform;
        } else {
            eagalBoid.persuitBehaviour.enabled = true;
            eagalBoid.persuitBehaviour.leader = spawnedLeader;
            eagalBoid.persuitBehaviour.Awake();

            eagalBoid.seekBehaviour.enabled = false;
        }
    }
    #endregion

}
