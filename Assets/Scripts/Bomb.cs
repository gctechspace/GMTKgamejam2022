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
            c.Level -= Damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(10, transform.position, 10, 1, ForceMode.VelocityChange);
        }
    }
}
