using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject ShieldObject;
    public GameObject newShield;
    public float ShieldHealth;
    public float ShieldHealthMax;
    public float ShieldDuration;
    public float ShieldRespawnTimer;
    public bool canSpawn;

    private void Start()
    {
        canSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("E"))
        {
            if (canSpawn == true)
            {
                newShield = Instantiate(ShieldObject);
                newShield.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                StartCoroutine(ShieldDurationTimer());
            }
        }

        if (canSpawn == false)
        {
            if (ShieldHealth <= 0)
            {
                Destroy(newShield);
                newShield = null;
                StartCoroutine(RespawnTimer());  
            }
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
        ShieldHealth = ShieldHealthMax;
    }
}
