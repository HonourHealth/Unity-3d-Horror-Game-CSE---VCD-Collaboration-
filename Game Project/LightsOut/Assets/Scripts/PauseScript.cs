using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{

    // Use this for initialization

    public bool paused;
    public Button mybutton;
    public Sprite pause_sprite;
    public Sprite continue_sprite;

    void Start()
    {
        paused = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void durdurma_butonu()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0;
            mybutton.image.overrideSprite = continue_sprite;
        }
        else if (!paused)
        {
            Time.timeScale = 1;
            mybutton.image.overrideSprite = pause_sprite;
        }
    }


}

