using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    //public Sprite off_sprite;
    //public Sprite on_sprite;
    public Button mybutton;

    public void LoadScene(int level)
    {
       
        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            //mybutton.image.overrideSprite = off_sprite;
        }
        else  {
            AudioListener.volume = 1f;
            //mybutton.image.overrideSprite = on_sprite;
        }
        Application.LoadLevel(level);
        
    }

}
