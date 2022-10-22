using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Space : MonoBehaviour
{
    int id = -1;

    public enum SpaceState { On, Off, Maybe };

    SpaceState state;

    Image image;

    public Sprite on_sprite;
    public Sprite off_sprite;
    public Sprite maybe_sprite;

    SpaceManager space_manager;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        state = SpaceState.Off;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void initialize(SpaceManager n_space_manager, int n_id)
    {
        id = n_id;
        space_manager = n_space_manager;
    }

    public void toggleOnOff()
    {
        if (Input.GetKey(KeyCode.R))
        {
            toggleMaybe();
        }
        else
        {
            if (state == SpaceState.Off || state == SpaceState.Maybe)
            {
                state = SpaceState.On;
                image.sprite = on_sprite;
            }
            else
            {
                turnOff();
            }
            if (space_manager.getPhase() == 1)
                space_manager.checkForCorrectPassword();
            else
                space_manager.checkForCorrectPassword2();
        }
    }

    public void turnOff()
    {
        state = SpaceState.Off;
        image.sprite = off_sprite;
    }

    public void toggleMaybe()
    {
        if (state != SpaceState.Maybe)
        {
            state = SpaceState.Maybe;
            image.sprite = maybe_sprite;
        }
        else
        {
            state = SpaceState.Off;
            image.sprite = off_sprite;
        }
    }

    public int getId()
    {
        return id;
    }

    public bool isOn()
    {
        if (state == SpaceState.On)
            return true;
        return false;
    }
}
