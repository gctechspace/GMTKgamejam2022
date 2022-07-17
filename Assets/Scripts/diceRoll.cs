using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class diceRoll : MonoBehaviour
{

    public Transform diceStart;
    public GameObject alldice;
    public Transform rollMat;
    public int difficulty;
    public int slope;
    public int gravity;
    public int other;


	//Difficulty 1-40 = Higher number less stairs
	//Slope 0-12 = Higher number more ramp/easier
	private void Start()
	{
      /*  GameObject mydice =  Instantiate(utility.randomdice());
        mydice.transform.position = diceStart.position;*/
	}
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


        List<int> diffy = new List<int>();
        List<int> grave = new List<int>();
        List<int> slo = new List<int>();
        List<int> Other = new List<int>();
        // Print the best dice faces
        foreach (Collider cols in bestDice)
		{
            print(cols.gameObject.name + " " + cols.transform.position.y + cols.transform.parent.name);


            if (cols.transform.position.x > rollMat.transform.position.x && cols.transform.position.z > rollMat.transform.position.z)
			{
                grave.Add(int.Parse(cols.gameObject.name)); //blue
			}
            if (cols.transform.position.x < rollMat.transform.position.x && cols.transform.position.z > rollMat.transform.position.z)
            {
                slo.Add(int.Parse(cols.gameObject.name)); //green
            }
            if (cols.transform.position.x > rollMat.transform.position.x && cols.transform.position.z < rollMat.transform.position.z)
            {
                diffy.Add(int.Parse(cols.gameObject.name)); //red
            }
            if (cols.transform.position.x < rollMat.transform.position.x && cols.transform.position.z < rollMat.transform.position.z)
            {
                Other.Add(int.Parse(cols.gameObject.name)); //purple
            }

        }

        difficulty = diffy.Sum();
        slope = slo.Sum();
        gravity = grave.Sum();
        other = Other.Sum();

    }

	
}
