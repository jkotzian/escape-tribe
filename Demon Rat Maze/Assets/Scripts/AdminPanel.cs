using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdminPanel : MonoBehaviour
{
    public Text sever_communication_text;
    public AudioSource alarm_sound_source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void severCommunication()
    {
        sever_communication_text.text = "Communication severed";
    }

    public void startSelfDestruct()
    {
        alarm_sound_source.Play();
        StartCoroutine(hideAdminPanel());
    }

    IEnumerator hideAdminPanel()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
    }
}
