using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        
    }


    public void Fade() {
        this.GetComponent<Animator>().SetTrigger("FadeOut");
    }
 
    public void OnFadeComplete() {
        MainMenu.ChangeScene();
    }
}
