using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraScript : MonoBehaviour {

    [SerializeField]
    float healAmount = 15f;

    [SerializeField]
    float healEvery = 2f;

    [SerializeField]
    float auraDuration = 10f;
    [SerializeField]
    float auraDistribution = 7f;

    IEnumerator coroutine;

    void Start() {
        coroutine = AddHealth(healEvery, healAmount);

        StartCoroutine(die(Random.Range(auraDuration-auraDistribution, auraDuration + auraDistribution)));

        

    }

    

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Child")){

            StartCoroutine(coroutine);

            collision.GetComponent<Animator>().SetBool("Charging",true);
            this.GetComponent<AudioSource>().Play();
        }else if (collision.gameObject.CompareTag("Enemy") && 0 == Random.Range(0,2)%2) {
            Destroy(collision.gameObject);
        }           

    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Child")) {

            collision.GetComponent<Animator>().SetBool("Charging", false);
            this.GetComponent<AudioSource>().Stop();

            StopCoroutine(coroutine);
        }
    }

    public IEnumerator AddHealth(float time, float healAmount) {
        while (true) {
            yield return new WaitForSeconds(time);

            if (ChildBehaviour.health < 200 - healAmount) {
                ChildBehaviour.health += healAmount;
            }
        }
    }
   
    void OnDestroy() {
        if (coroutine != null) StopCoroutine(coroutine);
    }

    IEnumerator die(float time) {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        yield return null;
    }

}
