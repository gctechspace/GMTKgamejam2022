using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeRemaining = 0;

    public bool Enabled = false;

    public GameObject Prefab = null;

    public int NumberOfObjectsToSpawn = 0;

    public int Frequency;

    private void resetTimer() {
        timeRemaining = Frequency;
    }

    private void reset () {
        Enabled = false;
        timeRemaining = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled) {
            return;
        }

        if (Frequency <= 0 || NumberOfObjectsToSpawn <= 0) {
            reset();
            return;
        }

        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
        } else {
            resetTimer();
            Instantiate(Prefab, transform.position, Quaternion.identity);
            NumberOfObjectsToSpawn--;
            if (NumberOfObjectsToSpawn <= 0) {
                reset();
            }
        }
    }
}
