using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int Level = 1000;

    public Slider Slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = Level;
    }

    void OnCollisionEnter(Collision collision) {
        int m = (int)collision.relativeVelocity.magnitude;
        Debug.Log("Collision detected with magnitude: " + m);

        if (m > 2) {
            Level -= m;
        }

        if (Level <= 0) {
            // TODO: Trigger end of life
        }
    }
}
