using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeflectorShield : MonoBehaviour
{
    public GameObject ShieldObject;
    public GameObject newShield;
    public bool canSpawn;
    public float ShieldDuration;
    public float ShieldRespawnTimer;

    void Start()
    {
        canSpawn = true;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<EricCharacterMovement>().DefenseToggleNum == 1)
        {
            if (Input.GetButtonDown("E"))
            {
                if (canSpawn == true)
                {
                    newShield = Instantiate(ShieldObject);
                    newShield.transform.position = GameObject.FindGameObjectWithTag("FrontalHoverPos").transform.position;
                    newShield.transform.parent = GameObject.FindGameObjectWithTag("FrontalHoverPos").transform;
                    newShield.transform.rotation = GameObject.FindGameObjectWithTag("FrontalHoverPos").transform.rotation;


                    StartCoroutine(ShieldDurationTimer());
                }                  
            }

            if (newShield != null)
            {
                newShield.transform.Rotate(0.0f, 0.0f, 1000.0f * Time.deltaTime, Space.Self);
            }
        }
        else
        {
            Destroy(newShield);
            newShield = null;
            canSpawn = true;
        }
    }

    IEnumerator ShieldDurationTimer()
    {
        canSpawn = false;
        yield return new WaitForSeconds(ShieldDuration);
        Destroy(newShield);
        newShield = null;
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(ShieldRespawnTimer);
        canSpawn = true;
    }
}
