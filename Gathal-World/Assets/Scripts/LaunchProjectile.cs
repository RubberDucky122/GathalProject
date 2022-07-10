using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public bool FireShot;
    public float ReloadTime;
    public float SetDamage;
    public GameObject newProjectile;
    public GameObject Projectile;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("EnemyTarget");
        FireShot = true;
    }

    void Update()
    {
        if (FireShot == true)
        {
            InitProjectile();
            FireShot = false;
            StartCoroutine(Reload());
        }
    }

    void InitProjectile()
    {
        Projectile = Instantiate(newProjectile);

        Projectile.GetComponent<Projectile>().transform.position = transform.position;

        Projectile.GetComponent<Projectile>().MovementSpeed =
            new Vector3(
            (player.transform.position.x - transform.position.x),
            2.0f,
            (player.transform.position.z - transform.position.z)).normalized;

        Projectile.GetComponent<Projectile>().DamageValue = SetDamage;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(ReloadTime);
        FireShot = true;
    }
}
