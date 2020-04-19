using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5f;
    
    [SerializeField]
    float rotationSpeed = 5f;

    [SerializeField]
    Transform target;

    [SerializeField]
    float damage = 20f;

    Vector2 movement;  
    Rigidbody2D enemyRigidbody;

    void Start(){
        if (GameObject.FindGameObjectWithTag("Child") == null) Destroy(this.gameObject);
        else target = GameObject.FindGameObjectWithTag("Child").transform;

        enemyRigidbody = this.GetComponent<Rigidbody2D>();
    }

    void Update(){
        try {
            //Rotation
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

            //Movement
            direction.Normalize();
            movement = direction;
        } catch { }

    }

    void FixedUpdate() {
        
        Move(movement);
        
    }

   void Move(Vector2 direction) {
        enemyRigidbody.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.fixedDeltaTime));
      
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
            if (collision.gameObject.CompareTag("Child")) {

                ChildBehaviour.health -= damage;
                Destroy(this.gameObject);
                
                
            }
        
    }


}
