using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    private Vector3 mousePosition;

    void Start() {

    }


    void Update() {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, mousePosition.y, 0f), new Vector3(mousePosition.x, mousePosition.y, -2.5f), speed);
    }
}
