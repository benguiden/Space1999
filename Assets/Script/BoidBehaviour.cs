using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class BoidBehaviour{

    #region Public Variables
    public bool enabled = false;
    #endregion

    protected Boid boid;

    public void SetBoid(Boid _boid) {
        boid = _boid;
    }

    public virtual void Awake() {}
    public virtual void Update() {}

}
