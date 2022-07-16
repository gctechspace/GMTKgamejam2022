using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] item;
    public int difficulty = 1;
    public int platformSlope = 0;
    private int NumberOfObjectsToSpawn = 116; // Number of stairs required to reach the tower top
    private int platformAngleIncrement = 15; // Degrees to rotate each platform object
    private float platformHieghtIncrement = 0.4f; // Height to increase each platform by
    private int startAngle = -120; // Starts the objects on the right side of the dice tower
    private float height = 0.2f; // platform Start height

    // Start is called before the first frame update
    void Start()
    {
        generate(item[0], NumberOfObjectsToSpawn, startAngle, platformAngleIncrement, height, platformHieghtIncrement, platformSlope, difficulty);  //platform
        generate(item[1], 30, startAngle, 45, 8, 1.2f, 0, 1); //torch (difficulty of 1 ALWAYS places an object)
    }

    
    void generate(GameObject obj, int units, int angle, int angleIncrement, float h, float hIncrement, int pSlope, int difficulty)
	{
        int stairGroup = NumberOfObjectsToSpawn / difficulty;
        for (int i = 0; i < units; i++)
        {
            if(i % stairGroup > 1 || i == 0) // Skips a stair every stair group, Higher difficulty more skipped stairs (Never skips 1st stair)
            {
                Instantiate(obj, new Vector3(0, h, 0), Quaternion.Euler(new Vector3(0, -angle, pSlope)));
            } else
            {
                // utility.random
            }
            angle += angleIncrement;
            h += hIncrement;

        }
    }

}
