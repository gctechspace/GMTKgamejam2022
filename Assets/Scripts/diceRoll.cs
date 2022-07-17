using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class diceRoll : MonoBehaviour
{

    public Transform diceStart;
    
    public Transform rollMat;
    public int difficulty;
    public int slope;
    public int gravity;
    public int other;
    int stopped = 0;
    

    public TextMeshProUGUI[] textoutputs;
    public Button startButtion;

	//Difficulty 1-40 = Higher number less stairs
	//Slope 0-12 = Higher number more ramp/easier

	private void Start()
	{
        Time.timeScale = 1f;
        global.winner = false;
      
        global.death = false;
        startButtion.interactable = false;

        textoutputs[5].text = global.level.ToString();
        textoutputs[6].text = global.score.ToString();
        textoutputs[7].text = global.highscore.ToString();

    }
	public void startGame()
	{
        SceneManager.LoadScene("SkipTower");
        

    }

    void waitToStop()
	{
		foreach (Transform dice in global.allDice.transform)
		{
            Rigidbody DRB =  dice.GetComponent<Rigidbody>();
            if(DRB.velocity.magnitude < 0.05f && dice.transform.position.y < 1f)
			{
                stopped++;
			}
		}
	}

	private void Update()
	{
        waitToStop();
		if(stopped == 6)
		{
            GetNumbers();
            stopped++;
		}
	}
	public void GetNumbers()
	{

        List<Collider> bestDice = new List<Collider>();

        // Enumerate each of the dice
        foreach (Transform dice in global.allDice.transform)
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
        if(difficulty == 0)
		{
            difficulty = 1;
		}
        
        
        slope = slo.Sum();
        if(slope > 12)
		{
            slope = 12;
		}
 
        gravity = grave.Sum();
        other = Other.Sum();

        textoutputs[0].text = difficulty.ToString();
        textoutputs[1].text = slope.ToString();
        textoutputs[2].text = gravity.ToString();
        textoutputs[3].text = other.ToString();

        startButtion.interactable = true;
        textoutputs[4].text = "Start";

          PlayerPrefs.SetInt("difficulty", difficulty);
          PlayerPrefs.SetInt("slope", slope);
        PlayerPrefs.SetInt("gravity", gravity);
        PlayerPrefs.SetInt("other", other);

    }

	
}
