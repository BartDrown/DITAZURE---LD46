using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    GameObject healthBar;
    // Start is called before the first frame update
    void Start() {
        healthBar = GameObject.FindGameObjectWithTag("HealthBar");
    }

    // Update is called once per frame
    void Update() {
        
        healthBar.transform.localScale = new Vector3(ChildBehaviour.health / 200f, 1f, 1f);
    }
}
