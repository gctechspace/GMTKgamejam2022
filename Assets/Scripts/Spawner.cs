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

    public bool diceScene;

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
		if (diceScene)
		{
            global.allDice = new GameObject();
            DontDestroyOnLoad(global.allDice);

        }
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
            Prefab = utility.randomdice();
			if (diceScene)
			{
                Prefab.transform.SetParent(global.allDice.transform) ;  //leave this alone
			}
            // Instantiate(Prefab, transform.position, Quaternion.identity);
            Prefab.transform.position = transform.position;
            NumberOfObjectsToSpawn--;
            if (NumberOfObjectsToSpawn <= 0) {
                reset();
            }
        }
    }
}
