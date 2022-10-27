using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;

    public AudioSource sound_source_1;
    public AudioSource sound_source_2;
    public AudioSource sound_source_3;

    void Awake()
    {
        if (!S)
        {
            //Debug.Log("Crash - 1");
            DontDestroyOnLoad(transform.gameObject);
            S = this;
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playSound(AudioClip clip)
    {
        if (!sound_source_1.isPlaying)
        {
            sound_source_1.clip = clip;
            sound_source_1.Play();
        }
        else if (!sound_source_2.isPlaying)
        {
            sound_source_2.clip = clip;
            sound_source_2.Play();
        }
        else if (!sound_source_3.isPlaying)
        {
            sound_source_3.clip = clip;
            sound_source_3.Play();
        }
    }
}
