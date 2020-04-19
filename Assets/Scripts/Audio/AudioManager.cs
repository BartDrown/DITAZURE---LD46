using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public AudioClip[] sounds;

    AudioSource source;
    // Start is called before the first frame update
    float check = 3f;
    void Start()
    {
        source = this.GetComponent<AudioSource>();

        playHashing();
    }

    void playHashing() {
        source.Stop();
        source.clip = sounds[(int)Random.Range(3, 7)];
        source.Play();
        source.pitch = Random.Range(0.12f, 0.8f);
    }
    
    void Update() {
         
        if (!source.isPlaying && check <= 0 ) {
            Invoke("playHashing", Random.Range(5,10));
            check = 3f;
        }
        check -= Time.deltaTime;
    }
    
    

}
