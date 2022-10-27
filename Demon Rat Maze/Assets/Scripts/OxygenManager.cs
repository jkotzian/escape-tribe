using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenManager : MonoBehaviour
{
    public Image fill_image;
    public Text oxygen_remaining_text_1;
    public Text oxygen_remaining_text_2;
    public Sprite fill_sprite_5;
    public Sprite fill_sprite_4;
    public Sprite fill_sprite_3;
    public Sprite fill_sprite_2;
    public Sprite fill_sprite_1;
    public int goal_oxygen_pct = 0;
    public int current_oxygen_pct = 100;
    public float update_oxygen_time = 8f;
    float slow_down_update_time_threshold = 10f;
    float slow_down_update_time_rate = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updateOxygen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator updateOxygen()
    {
        if (current_oxygen_pct <= goal_oxygen_pct)
            yield break;
        current_oxygen_pct--;
        oxygen_remaining_text_1.text = current_oxygen_pct.ToString() + "%";
        oxygen_remaining_text_2.text = current_oxygen_pct.ToString() + "%";
        if (current_oxygen_pct > 80)
            fill_image.sprite = fill_sprite_5;
        else if (current_oxygen_pct > 60)
            fill_image.sprite = fill_sprite_4;
        else if (current_oxygen_pct > 40)
            fill_image.sprite = fill_sprite_3;
        else if (current_oxygen_pct > 20)
            fill_image.sprite = fill_sprite_2;
        else 
            fill_image.sprite = fill_sprite_1;
        fill_image.fillAmount = (float) current_oxygen_pct / 100f;
        if (current_oxygen_pct < goal_oxygen_pct + slow_down_update_time_threshold)
        {
            update_oxygen_time *= slow_down_update_time_rate;
        }
        yield return new WaitForSeconds(update_oxygen_time);
        StartCoroutine(updateOxygen());
    }
}
