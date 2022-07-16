using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] item;
    public int NumberOfObjectsToSpawn = 38;
    private int nextAngle = -120;
    private float height = 0.8f;

    // Start is called before the first frame update
    void Start()
    {

        /*  for (int i = 0; i < NumberOfObjectsToSpawn; i++)
          {
              Instantiate(PlatformPrefab, new Vector3 (0, height, 0), Quaternion.Euler(new Vector3(0, -nextAngle, 0)));
              nextAngle += 45;
              height += 1.2f;

          }*/

        generate(item[0], NumberOfObjectsToSpawn, nextAngle, height);  //platform
        generate(item[1], 30, nextAngle, 8); //torch

    }

    
    void generate(GameObject obj, int units, int angle, float h )
	{
        for (int i = 0; i < units; i++)
        {
            Instantiate(obj, new Vector3(0, h, 0), Quaternion.Euler(new Vector3(0, -angle, 0)));
            angle += 45;
            h += 1.2f;

        }
    }

}
