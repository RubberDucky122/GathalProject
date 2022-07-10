using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageHitBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<EricCharacterMovement>().PlayerHP =
                GameObject.FindGameObjectWithTag("Player").GetComponent<EricCharacterMovement>().PlayerHP - other.GetComponent<Projectile>().DamageValue;
            Destroy(other.gameObject);
        }
    }
}
