using Neotek;

using UnityEngine;


public static class utility
{

    public static Neotek.WeightedList<GameObject> dicelist = new Neotek.WeightedList<GameObject>();
    public static Neotek.WeightedList<Color> colourlist = new Neotek.WeightedList<Color>();

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

    public static GameObject randomdice() {
        GameObject mydice = utility.dicelist.Next();
        mydice.transform.localPosition = new Vector3(3f, 3f, 9f);
        mydice.transform.rotation = Quaternion.Euler(utility.random(0, 360), utility.random(0, 360), 0);
        mydice.transform.GetComponent<Renderer>().material.color = utility.colourlist.Next();
        mydice.SetActive(true);
        return mydice;
    }
}