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
    public bool isGrounded;

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


        

		if (Input.GetButtonDown("Jump") && isGrounded)
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
		if (isGrounded)
		{
            RB.AddForce(rotation * speed * Time.deltaTime, 0, speed * forward * Time.deltaTime);

        }

    }
    void jump()
	{
        RB.AddForce(0, jumpForce, 0);
    }

	private void OnCollisionStay(Collision collision)
	{
        if(collision.gameObject.tag == "ground")
		{
            isGrounded = true;
        }
        
	}

	private void OnCollisionExit(Collision collision)
	{
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }
}
