using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    int num_passwords_to_solve = 0;
    List<PasswordInput> password_inputs;

    public bool play_outro_movie = false;
    public AudioSource audio_source;

    public GameObject video_canvas;

    // Start is called before the first frame update
    void Start()
    {
        num_passwords_to_solve = transform.childCount;
        for (int i = 0; i < num_passwords_to_solve; i++)
        {
            PasswordInput password_input = transform.GetChild(i).GetComponent<PasswordInput>();
            password_input.initialize(this, i + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passwordSolved()
    {
        num_passwords_to_solve--;
        if (num_passwords_to_solve == 0)
            StartCoroutine(playOutro());
    }

    IEnumerator playOutro()
    {
        yield return new WaitForSeconds(1f);
        if (num_passwords_to_solve == 0)
        {
            if (!play_outro_movie)
                GameManager.S.loadNextScene();
            else
            {
                video_canvas.SetActive(true);
                audio_source.Stop();
            }
        }
    }
}
