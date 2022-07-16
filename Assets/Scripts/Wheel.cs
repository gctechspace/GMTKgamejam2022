using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float rotateSpeed;
    Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        RB.AddTorque(0, rotateSpeed * Time.deltaTime, 0);
    }
}
