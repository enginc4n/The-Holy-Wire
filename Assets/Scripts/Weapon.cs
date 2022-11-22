using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public AudioSource sesler;
    public AudioClip skill1;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        sesler.PlayOneShot(skill1);
    }
}
