using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsEntity : MonoBehaviour {
    [SerializeField]
   public float speed = 5f;
    [SerializeField]
    Transform entityTransform;

    

    void Start() {
        if (entityTransform == null) entityTransform = GameObject.Find("character").transform;
    }


    void Update() {
        Vector2 direction = entityTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    }
}
