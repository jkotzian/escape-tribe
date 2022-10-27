using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    PasswordManager password_manager;
    public Text id_text;
    public InputField input_field;
    public Button submit_button;
    public string password_str;
    public GameObject checkmark;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize(PasswordManager n_password_manager, int password_id)
    {
        password_manager = n_password_manager;
        id_text.text = password_id.ToString();
    }

    public void submitPassword()
    {
        //Password was correct
        if (input_field.text == password_str)
        {
            Debug.Log("Success!");
            submit_button.gameObject.SetActive(false);
            checkmark.gameObject.SetActive(true);
            password_manager.passwordSolved();
        }
    }
}
