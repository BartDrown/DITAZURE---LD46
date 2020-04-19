using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float bulletForce = 20f;

    [SerializeField]
    float energyCost = 2f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }


    void Shoot() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        ChildBehaviour.health -= energyCost;

       

        this.GetComponent<AudioSource>().clip = GameObject.FindGameObjectWithTag("AudioManager").gameObject.GetComponent<AudioManager>().sounds[(int)Random.Range(0, 3)];

        this.GetComponent<AudioSource>().Play();
    }

}
