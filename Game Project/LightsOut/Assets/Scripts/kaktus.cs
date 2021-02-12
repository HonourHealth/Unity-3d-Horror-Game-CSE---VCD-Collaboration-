using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kaktus : MonoBehaviour
{
    public Slider myslide;
    void Start()
    {

    }

    void Update()
    {
       
    }
    
    
        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "Player")
            {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.scream);
                myslide.value -= 0.1f;
            }
        }
    
    
}