using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setup : MonoBehaviour
{

    public GameObject Dice;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform c in Dice.transform)
        {
            utility.dicelist.Add(c.gameObject, 1);
        }

        utility.colourlist.Add(utility.StringToColor("#68af1e"), 1);
        utility.colourlist.Add(utility.StringToColor("#fdfdfd"), 1);
        utility.colourlist.Add(utility.StringToColor("#9ebfed"), 1);
        utility.colourlist.Add(utility.StringToColor("#e3b505"), 1);
        utility.colourlist.Add(utility.StringToColor("#95190c"), 1);
        utility.colourlist.Add(utility.StringToColor("#610345"), 1);
        utility.colourlist.Add(utility.StringToColor("#044b7f"), 1);


        Instantiate(utility.randomdice());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
