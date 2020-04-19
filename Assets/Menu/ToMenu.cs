using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    public void toMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void PlayGameAgain() {
        SceneManager.LoadScene("SampleScene");
    }
}
