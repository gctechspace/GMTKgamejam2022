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

    //public static void playclip(int index)
    //{
    //    audiosource.pitch = 1;
    //    audiosource.PlayOneShot(audioclips.Items[index]);
    //}

    public static GameObject randomdice() {
        GameObject mydice = utility.dicelist.Next();
        mydice.transform.localPosition = new Vector3(3f, 3f, 9f);
        mydice.transform.rotation = Quaternion.Euler(utility.random(0, 360), utility.random(0, 360), 0);
        mydice.transform.GetComponent<Renderer>().material.color = utility.colourlist.Next();
        mydice.SetActive(true);
        return mydice;
    }

}

public static class global
{
    public static GameObject allDice;

}