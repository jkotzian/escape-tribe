using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class SpaceManager : MonoBehaviour
{
    public Transform grid_parent;
    public Transform spaces_parent;
    public Text success_text;
    public GameObject website_field;
    public GameObject video_canvas;
    public VideoPlayer video_player;
    public GameObject background;
    List<Space> spaces;
    List<int> password_1_on_ids_list;
    int[] password_1_on_ids = {3, 4, 5, 8, 14, 17, 20, 23, 24, 25, 26, 28, 29, 30, 31, 32, 34, 38, 43};
    List<List<Space>> spaces_grid;
    int[] on_counts_for_rows = { 3, 6, 5, 5, 1 };
    int[] on_counts_for_cols = { 1, 1, 4, 1, 4, 1, 4, 1, 3 };
    const int NUM_COLS = 9;
    const int NUM_ROWS = 5;
    int phase = 1;
    // Start is called before the first frame update

    
    void Start()
    {
        spaces_grid = new List<List<Space>>();
        password_1_on_ids_list = new List<int>(password_1_on_ids);
        spaces = new List<Space>();
        List<Space> row = new List<Space>();
        for (int i = 1; i <= spaces_parent.childCount; ++i)
        {
            if (i != 1 && (i - 1) % NUM_COLS == 0)
            {
                spaces_grid.Add(row);
                row = new List<Space>();
            }
            Space space = spaces_parent.GetChild(i - 1).GetComponent<Space>();
            // The IDs are 1 based
            space.initialize(this, i);
            row.Add(space);
            spaces.Add(space);
        }
        spaces_grid.Add(row);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void turnAllSpacesOff()
    {
        foreach (Space space in spaces)
        {
            space.turnOff();
        }
    }

    public void checkForCorrectPassword()
    {
        bool password_correct = true;
        foreach (Space space in spaces)
        {
            // If the space is on but it shouldn't be
            if (space.isOn() && !password_1_on_ids_list.Contains(space.getId()))
            {
                password_correct = false;
                break;
            }
            // If the space is off but it should be
            else if (!space.isOn() && password_1_on_ids_list.Contains(space.getId()))
            {
                password_correct = false;
                break;
            }
        }
        if (password_correct)
        {
            StartCoroutine(progressToSecondPhase());
        }
    }

    IEnumerator progressToSecondPhase()
    {
        Debug.Log("Success!!");
        yield return new WaitForSeconds(1f);
        grid_parent.gameObject.SetActive(false);
        success_text.gameObject.SetActive(true);
        success_text.text = "success (1/2)";
        yield return new WaitForSeconds(2f);
        website_field.gameObject.SetActive(true);
        success_text.gameObject.SetActive(false);
        turnAllSpacesOff();
        grid_parent.gameObject.SetActive(true);
        phase++;
    }

    IEnumerator progressToOutro()
    {
        Debug.Log("Success!!");
        yield return new WaitForSeconds(1f);
        grid_parent.gameObject.SetActive(false);
        success_text.gameObject.SetActive(true);
        success_text.text = "Access Granted";
        yield return new WaitForSeconds(2f);
        success_text.gameObject.SetActive(false);
        video_canvas.gameObject.SetActive(true);
        // Wait for it to play
        while (!video_player.isPlaying)
            yield return null;
        background.SetActive(false);
        // Then wait for it to not play
        while (video_player.isPlaying)
            yield return null;
        while (!Input.GetKeyDown(KeyCode.Space))
            yield return null;
        GameManager.S.loadNextScene();
    }

    public int getPhase()
    {
        return phase;
    }

    public void checkForCorrectPassword2()
    {
        bool password_correct = true;
        // Check each row
        for (int row = 0; row < NUM_ROWS; ++row)
        {
            if (!checkRowForCorrectOnCount(row, on_counts_for_rows[row]))
                password_correct = false;
        }
        // Check each col
        for (int col = 0; col < NUM_COLS; ++col)
        {
            if (!checkColForCorrectOnCount(col, on_counts_for_cols[col]))
                password_correct = false;
        }
        if (password_correct)
        {
            Debug.Log("Success!!");
            StartCoroutine(progressToOutro());
        }
    }

    public bool checkRowForCorrectOnCount(int row, int required_on_count)
    {
        int on_count = 0;
        for (int col = 0; col < NUM_COLS; ++col)
        {
            if (spaces_grid[row][col].isOn())
                on_count++;
        }
        if (on_count != required_on_count)
            return false;
        return true;
    }

    public bool checkColForCorrectOnCount(int col, int required_on_count)
    {
        int on_count = 0;
        for (int row = 0; row < NUM_ROWS; ++row)
        {
            if (spaces_grid[row][col].isOn())
                on_count++;
        }
        if (on_count != required_on_count)
            return false;
        return true;
    }
}
