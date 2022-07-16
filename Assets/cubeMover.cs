using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cubeMover : MonoBehaviour
{
    public float speed = 500f;  //can be seen and edited and overwriten in the Unity Inspector tab
    
    public float jumpForce = 50f;
    float forward;
    float rotation;
    private Rigidbody RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetAxis("Vertical"); //this can be "W" key,the up arrow key or a joystick/controller input.
   
       
     
        rotation = Input.GetAxis("Horizontal");


        

		if (Input.GetButtonDown("Jump"))
		{
            jump();
		}

        if (transform.position.y < -1) //fall off , reset level
        {
            //requires "using UnityEngine.SceneManagement;
            SceneManager.LoadScene("tower"); //call scene by scene name string
        }
    }
	private void FixedUpdate()
	{
        // transform.position = transform.position + transform.forward * speed * forward * Time.deltaTime;  //deltaTime keeps actions timing consitant in realation to framerate 
        RB.AddForce(rotation * speed * Time.deltaTime, 0, speed * forward * Time.deltaTime);


        //transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime); //method that rotates around axis(up or Y in this case)

    }
    void jump()
	{
        //RB.velocity = new Vector3(RB.velocity.x, jumpForce, RB.velocity.z);
        RB.AddForce(0, jumpForce, 0);
    }
}
