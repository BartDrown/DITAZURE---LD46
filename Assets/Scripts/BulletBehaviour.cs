using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject hitEffect;

    [SerializeField]
    float scorePerKill = 200;

    void OnCollisionEnter2D(Collision2D collision){
        if (hitEffect != null)
            Instantiate(hitEffect, transform.position, Quaternion.identity);

        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
            Game.score += scorePerKill;
        }
        Destroy(gameObject);
        
    }

    void Update() { }
}
