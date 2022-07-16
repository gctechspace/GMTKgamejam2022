using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
	public string tagname;
	public float power;

	

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == tagname)
		{
			Rigidbody RB = other.gameObject.GetComponent<Rigidbody>();
			RB.AddForce(transform.forward * power * Time.deltaTime);
		}
	}
}
