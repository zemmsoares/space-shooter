using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonusByContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        Debug.Log(other.name);
        Destroy(gameObject);
    }

}
