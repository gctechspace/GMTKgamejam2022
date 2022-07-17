using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class diceRoll : MonoBehaviour
{

    string[] numberStrings;
    public bool ready;

    public GameObject alldice;
    public Transform rollMat;
    public int difficulty;
    public int slope;
    public int gravity;


    

    void Start()
    {
        
        
    }
    //Difficulty 1-40 = Higher number less stairs
    //Slope 0-12 = Higher number more ramp/easier
    //*public void getNumbers()

    public void GetNumbers()
	{
        List<Collider> bestDice = new List<Collider>();

        // Enumerate each of the dice
        foreach (Transform dice in alldice.transform)
        {
            float bestHeight = 999999f;
            Collider bestCollider = null;

            // Enumerate each of the dice faces
            foreach (Transform face in dice.gameObject.transform)
            {
                // Go through each collider of the face and check if its the lowest height transform
                // for the entire dice
                Collider[] faceColliders = face.GetComponentsInChildren<Collider>();

                foreach (Collider collider in faceColliders)
                {
                    // Get the colliders height and see if it's the lowest found so far
                    float height = collider.transform.position.y;
                    
                    if (height < bestHeight)
                    {
                        bestCollider = collider;
                        bestHeight = height;
                    }
                }
            }

            // Add the best collider for this dice to the list
            if (bestCollider != null)
            {
                bestDice.Add(bestCollider);
            }
        }

        

        // Print the best dice faces
        foreach (Collider cols in bestDice)
		{
            print(cols.gameObject.name + " " + cols.transform.position.y + cols.transform.parent.name);
            //if col.transform.x > rollMat.transform.x && col.transform.z > rollMat.transform.z
            //{ add to Gravity = blue}
            //if col.transform.x < rollMat.transform.x && col.transform.z > rollMat.transform.z
            //{ add to slope = green]
            //if col.transform.x > rollMat.transform.x && col.transform.z < rollMat.transform.z
            //{ difficuty  = red}
            //else
            //{
            //  other = purple
            //list.Sum()
            //}
        }


    }

	
}
