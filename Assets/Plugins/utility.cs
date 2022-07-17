using Neotek;

using UnityEngine;


public static class utility
{

    public static Neotek.WeightedList<GameObject> dicelist = new Neotek.WeightedList<GameObject>();
    public static Neotek.WeightedList<Color> colourlist = new Neotek.WeightedList<Color>();
    public static Neotek.WeightedList<AudioClip> audioclips = new Neotek.WeightedList<AudioClip>();
    public static AudioSource audiosource;

    public static Color StringToColor(string colorStr)
    {
        Color c;
        ColorUtility.TryParseHtmlString(colorStr, out c);
        return c;
    }

    public static float random(float main, float offset)
    {
        return main + UnityEngine.Random.value * offset;
    }
    public static bool randomBoolean()
    {
        return (UnityEngine.Random.value > 0.5f);
    }

    public static void playclip(int index)
    {
        audiosource.pitch = 1;
        audiosource.PlayOneShot(audioclips.Items[index]);
    }

    public static GameObject randomdice()
    {

        GameObject mydice=null;
        try
        {
            if (utility.dicelist.Count != 0)
            {
                mydice = utility.dicelist.Next();
                if (mydice is object)
                {
                    mydice.transform.localPosition = new Vector3(3f, 3f, 9f);
                    mydice.transform.rotation = Quaternion.Euler(utility.random(0, 360), utility.random(0, 360), 0);
                    mydice.transform.GetComponent<Renderer>().material.color = utility.colourlist.Next();
                    mydice.SetActive(true);
                    utility.playclip(3);
                }
            }
           
        }
        catch (System.Exception e)
        {

            Debug.Log(e.Message);
            //throw;
        }

        return mydice;
    }

}

public static class global
{
    public static GameObject allDice;
    public static int health;
    public static int score;
    public static int highscore;
    public static int level = 1;
    public static int bankedscore = 0;
    public static float gravity = 0;
    public static int difficulty = 0;
    public static int other = 0;

}