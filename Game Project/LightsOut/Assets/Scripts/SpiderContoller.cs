using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpiderContoller : MonoBehaviour {

    public float speedSmoothTime = 0.1f;
    float collision = 0;

    public Slider myslide;

    Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

    }

    // Update is called once per framed

    void OnCollisionEnter(Collision col)
    {

        if ((col.gameObject.tag == "Player"))
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.scream);
            collision = 1;
            myslide.value -= 0.1f;

        }

        
    }
    void Update () {

        bool running = false;
        if (collision == 1)
        {
            //running = true;
            animator.Play("New State 0");
            collision = 0;
        }
        //float animationSpeedPercent = ((running) ? 1: 0);
       // animator.SetFloat("detection", collision, speedSmoothTime, Time.deltaTime);
        

    }
}
