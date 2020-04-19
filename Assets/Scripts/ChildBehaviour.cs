using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildBehaviour : MonoBehaviour {
    [SerializeField]
    float movementSpeed = 5f;

    [SerializeField]
    float rotationSpeed = 5f;

    [SerializeField]
    Transform target;

    [SerializeField]
    float holdDistance;

    [SerializeField]
    float depletionAmount, depletionPeriod;

    Vector2 movement;
    Rigidbody2D childRigidbody;
    IEnumerator healthCoroutine;

    static public float health = 50;

    static public bool dead;

    void Start() {
        if (target == null) target = GameObject.FindGameObjectWithTag("Player").transform;

        childRigidbody = this.GetComponent<Rigidbody2D>();

        healthCoroutine = depleteHealth(depletionAmount, depletionPeriod);
        StartCoroutine(healthCoroutine);
 
    }

    void Update() {

        //Rotation
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);

        //Movement
        direction.Normalize();
        movement = direction;

        if( health < 0 && !dead) {
            dead = true;
            Destroy(GameObject.FindGameObjectWithTag("HealthBar"));
            death();

        }

    }

    void FixedUpdate() {
        if (holdDistance/10 < Vector3.Distance(target.position, transform.position)) {
            Move(movement);
        }
    }

    void Move(Vector2 direction) {
        childRigidbody.MovePosition((Vector2)transform.position + (direction * movementSpeed * Time.fixedDeltaTime));

    }


    IEnumerator depleteHealth(float amount, float time) {
        while (true) {
            yield return new WaitForSeconds(time);
            health -= amount;
        }
    }

    void death() {
        Debug.Log("You are dead");
        StopCoroutine(healthCoroutine);
        GameObject.FindGameObjectWithTag("Gamecontroller").GetComponent<Game>().end();

        Destroy(this.gameObject);


    }

    
}
