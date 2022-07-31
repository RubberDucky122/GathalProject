using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDeflector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            Destroy(other.gameObject);
        }
    }
}
