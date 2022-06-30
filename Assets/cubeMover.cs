using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubeMover : MonoBehaviour
{
    public float speed = 5f;  //can be seen and edited and overwriten in the Unity Inspector tab
    public float rotationSpeed = 100f;  


    private Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical"); //this can be "W" key,the up arrow key or a joystick/controller input.
   
       
        transform.position = transform.position + transform.forward * speed * forward *Time.deltaTime;  //deltaTime keeps actions timing consitant in realation to framerate 
     
        float rotation = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * rotation * rotationSpeed*  Time.deltaTime); //method that rotates around axis(up or Y in this case)
        

        if(transform.position.y < -1) //fall off , reset level
        {
            //requires "using UnityEngine.SceneManagement;
            SceneManager.LoadScene("SampleScene"); //call scene by scene name string
        }
    }
}
