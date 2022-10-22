using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager S;
    int current_oxygen_level = 100;
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

    public void setCurrentOxygenLevel(int cur_level)
    {
        current_oxygen_level = cur_level;
    }

    public int getCurrenOxygenLevel()
    {
        return current_oxygen_level;
    }
}
