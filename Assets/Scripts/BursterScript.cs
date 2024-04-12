using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BursterScript : MonoBehaviour
{
    public enum EntityLivenessState { Alive, Dead }
    public enum MovementState { Fixed, Stationary, Moving }

    public float age;

    public float spurtAge = 10;

    public Vector3 growthSide = new(1, 1, 1);
    public Vector3 positionScale = new(0, 0.5f, 0);

    public EntityLivenessState state;
    public MovementState movementState;
    // Start is called before the first frame update
    void Start()
    {
        // state = EntityLivenessState.Alive;
        // movementState = MovementState.Stationary;
        // age = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // age += Time.deltaTime;
        // transform.localScale = growthSide * age;
        // transform.position = positionScale * age;
    }
}
