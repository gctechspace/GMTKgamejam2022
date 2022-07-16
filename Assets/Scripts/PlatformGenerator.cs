using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public int NumberOfObjectsToSpawn = 38;
    private int nextAngle = -120;
    private float height = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < NumberOfObjectsToSpawn; i++)
        {
            Instantiate(PlatformPrefab, new Vector3 (0, height, 0), Quaternion.Euler(new Vector3(0, -nextAngle, 0)));
            nextAngle += 45;
            height += 1.2f;

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }


}
