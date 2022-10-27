using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public List<Text> direction_texts;

    public Color north_color;
    public Color east_color;
    public Color west_color;
    public Color south_color;

    // Start is called before the first frame update
    void Start()
    {
        updateDirectionColors();
    }

    public void rotate(MoveType move_type)
    {
        if (!gameObject.activeSelf)
            return;
        if (move_type == MoveType.Forward)
            return;
        else if (move_type == MoveType.Right)
        {
            StartCoroutine(rotateDirections(1, false));
        }
        else if (move_type == MoveType.Left)
        {
            StartCoroutine(rotateDirections(1, true));
        }
        else if (move_type == MoveType.TurnAround)
        {
            StartCoroutine(rotateDirections(2, true));
        }
    }

    public IEnumerator rotateDirections(int num_rotations, bool counter_clockwise)
    {

        Animator animator = GetComponent<Animator>();
        // Animations
        if (num_rotations == 2)
        {
            animator.SetTrigger("rotate_180");
        }
        else if (num_rotations == 1 && counter_clockwise)
        {
            animator.SetTrigger("rotate_clockwise");
        }
        else if (num_rotations == 1 && !counter_clockwise)
        {
            animator.SetTrigger("rotate_counterclockwise");
        }

        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        yield return new WaitForSeconds(clips[0].length);

        for (int i = 0; i < num_rotations; ++i) 
        {
            string prev_direction_str = "";
            if (counter_clockwise)
            {
                // Get the direction text in the left direction slot
                prev_direction_str = direction_texts[direction_texts.Count - 1].text;
            }
            else
            {
                // Get the direction text in the right direction slot
                prev_direction_str = direction_texts[0].text;
            }

            int direction_text_index = 0;

            if (!counter_clockwise)
                direction_text_index = direction_texts.Count - 1;

            while (direction_text_index >= 0 && direction_text_index < direction_texts.Count)
            {
                string cur_direction_str = direction_texts[direction_text_index].text;
                direction_texts[direction_text_index].text = prev_direction_str;
                prev_direction_str = cur_direction_str;

                if (counter_clockwise)
                    direction_text_index++;
                else
                    direction_text_index--;
            }
        }

        updateDirectionColors();
    }

    public void updateDirectionColors()
    {
        for (int i = 0; i < direction_texts.Count; ++i)
        {
            if (direction_texts[i].text == "N")
                direction_texts[i].color = north_color;
            else if (direction_texts[i].text == "E")
                direction_texts[i].color = east_color;
            else if (direction_texts[i].text == "W")
                direction_texts[i].color = west_color;
            else if (direction_texts[i].text == "S")
                direction_texts[i].color = south_color;
        }
    }
}
