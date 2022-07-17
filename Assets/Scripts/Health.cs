using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int Level = 1000;

    public Slider Slider;

    public int Vulnerability = 2;
    public AudioSource tick;
    public AudioSource ouch;
    public AudioSource explosion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Slider.value = Level;
        global.health = Level;
    }

    void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Finish")
        {

            Debug.Log("Level Complete" );
            Level = 1000;
            global.health = 1000;
            global.level++;
            global.bankedscore += global.score;
            SceneManager.LoadScene("tower 1");
        }
    }


    void OnCollisionEnter(Collision collision)
    {


        int m = (int)collision.relativeVelocity.magnitude;

        //Debug.Log("Collided with: " + collision.gameObject.tag);
        Debug.Log("Collision detected with magnitude: " + m);

        switch (m)
        {
            case > 10:
                ouch.Play();
                break;
            case >= 1:
                tick.Play();
                break;
            default:
                break;
        }

        if (m > Vulnerability)
        {
            Level -= m;
        }

        if (Level <= 0)
        {
            // TODO: Trigger end of life
        }
    }

    void OnCollisionStay(Collision collision)
    {
        //tick.enabled = true;
    }
    void OnCollisionExit(Collision collision)
    {
        //tick.enabled = false;
    }

}
