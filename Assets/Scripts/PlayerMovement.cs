using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 1f;

    float verticalMove = 0f;
    float horizontalMove = 0f;

    CharacterController character;

    void Start() {
        this.gameObject.AddComponent<CharacterController>();
        character = GetComponent<CharacterController>();
    }

    void Update(){
        verticalMove = Input.GetAxisRaw("Vertical") * speed;
        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
    }

    void FixedUpdate(){

        
        character.Move( new Vector3 (horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime, 0));

    }
}
