using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int Damage = 200;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        Health c = (collision.gameObject.GetComponent("Health") as Health);
        if (c != null) {
            Debug.Log("Collided with something with the health script attached");
            c.Level -= Damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }    
}
