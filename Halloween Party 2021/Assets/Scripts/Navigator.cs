using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Navigator : MonoBehaviour
{
    public GameObject forward_arrow;
    public GameObject left_arrow;
    public GameObject right_arrow;
    public GameObject back_arrow;

    public Image background_image;

    Intersection current_intersection;
    public Text current_intersection_text;
    public Text fuses_found_text;

    public Sprite vent_dead_end_sprite;
    public Sprite vent_left_sprite;
    public Sprite vent_right_sprite;
    public Sprite vent_left_right_sprite;
    public Sprite vent_left_forward_sprite;
    public Sprite vent_right_forward_sprite;
    public Sprite vent_left_right_forward_sprite;
    public Sprite vent_forward_sprite;

    public GameObject video_canvas;
    public VideoPlayer video_player;

    Intersection intersection_1;
    Intersection intersection_2;
    Intersection intersection_3;
    Intersection intersection_4;
    Intersection intersection_5;
    Intersection intersection_6;
    Intersection intersection_7;
    Intersection intersection_8;
    Intersection intersection_9;
    Intersection intersection_10;
    Intersection intersection_11;
    Intersection intersection_12;
    Intersection intersection_13;
    Intersection intersection_14;
    Intersection intersection_15;
    Intersection intersection_16;
    Intersection intersection_17;
    Intersection intersection_18;
    Intersection intersection_19;
    Intersection intersection_20;
    Intersection intersection_21;
    Intersection intersection_22;
    Intersection intersection_23;
    Intersection intersection_24;
    Intersection intersection_25;
    Intersection intersection_26;
    Intersection intersection_27;
    Intersection intersection_28;
    Intersection intersection_29;
    Intersection intersection_30;
    Intersection intersection_31;
    Intersection intersection_32;
    Intersection intersection_33;
    Intersection intersection_34;
    Intersection intersection_35;
    Intersection intersection_36;
    Intersection intersection_37;
    Intersection intersection_38;
    Intersection intersection_39;
    Intersection intersection_40;
    Intersection intersection_41;
    Intersection intersection_42;
    Intersection intersection_43;
    Intersection intersection_44;
    Intersection intersection_45;
    Intersection intersection_46;
    Intersection intersection_47;
    Intersection intersection_48;
    Intersection intersection_49;
    Intersection intersection_50;

    int fuses_found = 0;
    int goal_fuses = 5;

    public static Navigator S;

    void Awake()
    {
        if (!S)
        {
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
        intersection_1 = new Intersection();
        intersection_2 = new Intersection();
        intersection_3 = new Intersection();
        intersection_4 = new Intersection();
        intersection_5 = new Intersection();
        intersection_6 = new Intersection();
        intersection_7 = new Intersection();
        intersection_8 = new Intersection();
        intersection_9 = new Intersection();
        intersection_10 = new Intersection();
        intersection_11 = new Intersection();
        intersection_12 = new Intersection();
        intersection_13 = new Intersection();
        intersection_14 = new Intersection();
        intersection_15 = new Intersection();
        intersection_16 = new Intersection();
        intersection_17 = new Intersection();
        intersection_18 = new Intersection();
        intersection_19 = new Intersection();
        intersection_20 = new Intersection();
        intersection_21 = new Intersection();
        intersection_22 = new Intersection();
        intersection_23 = new Intersection();
        intersection_24 = new Intersection();
        intersection_25 = new Intersection();
        intersection_26 = new Intersection();
        intersection_27 = new Intersection();
        intersection_28 = new Intersection();
        intersection_29 = new Intersection();
        intersection_30 = new Intersection();
        intersection_31 = new Intersection();
        intersection_32 = new Intersection();
        intersection_33 = new Intersection();
        intersection_34 = new Intersection();
        intersection_35 = new Intersection();
        intersection_36 = new Intersection();
        intersection_37 = new Intersection();
        intersection_38 = new Intersection();
        intersection_39 = new Intersection();
        intersection_40 = new Intersection();
        intersection_41 = new Intersection();
        intersection_42 = new Intersection();
        intersection_43 = new Intersection();
        intersection_44 = new Intersection();
        intersection_45 = new Intersection();
        intersection_46 = new Intersection();
        intersection_47 = new Intersection();
        intersection_48 = new Intersection();
        intersection_49 = new Intersection();
        intersection_50 = new Intersection();

        intersection_1.initialize(1, null, null, intersection_2, intersection_6);
        intersection_2.initialize(2, null, intersection_1, null, null);
        intersection_3.initialize(3, null, null, intersection_4, intersection_8);
        intersection_4.initialize(4, null, intersection_3, intersection_5, intersection_11);
        intersection_5.initialize(5, null, intersection_4, intersection_6, intersection_13);
        intersection_6.initialize(6, intersection_1, intersection_5, intersection_7, intersection_15);
        intersection_7.initialize(7, null, intersection_6, null, intersection_16);
        intersection_8.initialize(8, intersection_3, null, intersection_9, intersection_17);
        intersection_9.initialize(9, null, intersection_8, intersection_10, intersection_18);
        intersection_10.initialize(10, null, intersection_9, null, intersection_19);
        intersection_11.initialize(11, intersection_4, null, intersection_12, null);
        intersection_12.initialize(12, null, intersection_11, null, null);
        intersection_13.initialize(13, intersection_5, null, intersection_14, null);
        intersection_14.initialize(14, null, intersection_13, intersection_15, intersection_24);
        intersection_15.initialize(15, intersection_6, intersection_14, intersection_16, null);
        intersection_16.initialize(16, intersection_7, intersection_15, null, null);
        intersection_17.initialize(17, intersection_8, null, intersection_18, null);
        intersection_18.initialize(18, intersection_9, intersection_17, null, intersection_28);
        intersection_19.initialize(19, intersection_10, null, intersection_20, intersection_29);
        intersection_20.initialize(20, null, intersection_19, intersection_21, intersection_39);
        intersection_21.initialize(21, null, intersection_20, null, intersection_31);
        intersection_22.initialize(22, null, null, intersection_23, intersection_32);
        intersection_23.initialize(23, intersection_24, intersection_22, null, null);
        intersection_24.initialize(24, intersection_14, null, intersection_25, intersection_23);
        intersection_25.initialize(25, null, intersection_24, intersection_26, intersection_34);
        intersection_26.initialize(26, null, intersection_25, null, intersection_35);
        intersection_27.initialize(27, null, null, intersection_28, intersection_36);
        intersection_28.initialize(28, intersection_18, intersection_27, intersection_29, intersection_37);
        intersection_29.initialize(29, intersection_19, intersection_28, null, intersection_38);
        intersection_30.initialize(30, intersection_31, null, null, null);
        intersection_31.initialize(31, intersection_21, null, intersection_32, intersection_30);
        intersection_32.initialize(32, intersection_22, intersection_31, intersection_33, intersection_42);
        intersection_33.initialize(33, null, intersection_32, null, intersection_46);
        intersection_34.initialize(34, intersection_25, null, intersection_35, intersection_47);
        intersection_35.initialize(35, intersection_26, intersection_34, null, intersection_49);
        intersection_36.initialize(36, intersection_27, null, intersection_37, intersection_50);
        intersection_37.initialize(37, intersection_28, intersection_36, null, null);
        intersection_38.initialize(38, intersection_29, null, intersection_39, null);
        intersection_39.initialize(39, intersection_20, intersection_38, intersection_40, null);
        intersection_40.initialize(40, null, intersection_39, intersection_41, null);
        intersection_41.initialize(41, intersection_42, intersection_40, null, null);
        intersection_42.initialize(42, intersection_32, null, intersection_43, intersection_41);
        intersection_43.initialize(43, null, intersection_42, null, intersection_44);
        intersection_44.initialize(44, intersection_43, null, intersection_45, null);
        intersection_45.initialize(45, intersection_46, intersection_44, null, null);
        intersection_46.initialize(46, intersection_33, null, intersection_47, intersection_45);
        intersection_47.initialize(47, intersection_34, intersection_46, null, null);
        intersection_48.initialize(48, null, null, intersection_49, null);
        intersection_49.initialize(49, intersection_35, intersection_48, null, null);
        intersection_50.initialize(50, intersection_36, null, null, null);


        current_intersection = intersection_40;

        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveForward()
    {
        Intersection next_intersection = current_intersection.getForward();
        next_intersection.moveToIntersection(current_intersection.getBackDirection());
        current_intersection = next_intersection;
        updateUI();
    }

    public void moveLeft()
    {
        Intersection next_intersection = current_intersection.getLeft();
        next_intersection.moveToIntersection(current_intersection.getRightDirection());
        current_intersection = next_intersection;
        updateUI();
    }

    public void moveRight()
    {
        Intersection next_intersection = current_intersection.getRight();
        next_intersection.moveToIntersection(current_intersection.getLeftDirection());
        current_intersection = next_intersection;
        updateUI();
    }

    public void moveBack()
    {
        Intersection next_intersection = current_intersection.getBack();
        next_intersection.moveToIntersection(current_intersection.getForwardDirection());
        current_intersection = next_intersection;
        updateUI();
    }

    public void turnAround()
    {
        current_intersection.moveToIntersection(current_intersection.getForwardDirection());
        updateUI();
    }

    void updateUI()
    {
        if (current_intersection == null)
            return;
        if (current_intersection.getForward() != null)
            forward_arrow.SetActive(true);
        else
            forward_arrow.SetActive(false);
        if (current_intersection.getLeft() != null)
            left_arrow.SetActive(true);
        else
            left_arrow.SetActive(false);
        if (current_intersection.getRight() != null)
            right_arrow.SetActive(true);
        else
            right_arrow.SetActive(false);
        if (current_intersection.getBack() != null)
            back_arrow.SetActive(true);
        else
            back_arrow.SetActive(false);
        // Back
        if (current_intersection.getForward() == null && current_intersection.getLeft() == null && 
            current_intersection.getRight() == null)
        {
            background_image.sprite = vent_dead_end_sprite;
        }
        // Left
        if (current_intersection.getForward() == null && current_intersection.getLeft() != null &&
            current_intersection.getRight() == null)
        {
            background_image.sprite = vent_left_sprite;
        }
        // Right
        if (current_intersection.getForward() == null && current_intersection.getLeft() == null &&
            current_intersection.getRight() != null)
        {
            background_image.sprite = vent_right_sprite;
        }
        // Left right
        if (current_intersection.getForward() == null && current_intersection.getLeft() != null &&
            current_intersection.getRight() != null)
        {
            background_image.sprite = vent_left_right_sprite;
        }
        // Left forward
        if (current_intersection.getForward() != null && current_intersection.getLeft() != null &&
            current_intersection.getRight() == null)
        {
            background_image.sprite = vent_left_forward_sprite;
        }
        // Right forward
        if (current_intersection.getForward() != null && current_intersection.getLeft() == null &&
            current_intersection.getRight() != null)
        {
            background_image.sprite = vent_right_forward_sprite;
        }
        // Left right forward
        if (current_intersection.getForward() != null && current_intersection.getLeft() != null &&
            current_intersection.getRight() != null)
        {
            background_image.sprite = vent_left_right_forward_sprite;
        }
        // Forward
        if (current_intersection.getForward() != null && current_intersection.getLeft() == null &&
            current_intersection.getRight() == null)
        {
            background_image.sprite = vent_forward_sprite;
        }
        current_intersection_text.text = current_intersection.getID().ToString();
    }

    public void foundGoal()
    {
        fuses_found++;
        fuses_found_text.text = fuses_found.ToString() + "/" + goal_fuses.ToString();
        if (fuses_found == goal_fuses)
        {
            Debug.Log("Finished puzzle!!!");
            StartCoroutine(playOutro());
        }
    }

    IEnumerator playOutro()
    {
        video_canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        // Wait for it to play
        while (!video_player.isPlaying)
            yield return null;
        left_arrow.SetActive(false);
        right_arrow.SetActive(false);
        forward_arrow.SetActive(false);
        back_arrow.SetActive(false);
        current_intersection_text.gameObject.SetActive(false);
        // Then wait for it to not play
        while (video_player.isPlaying)
            yield return null;
        while (!Input.GetKeyDown(KeyCode.Space))
            yield return null; 
        GameManager.S.loadNextScene();
    }
}
