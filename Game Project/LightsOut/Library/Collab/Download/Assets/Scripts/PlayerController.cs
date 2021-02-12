using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public int target_score;
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public int level;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    public int score = 0;

    public bool running;

    Animator animator;
    Transform cameraT;


    public Slider myslide;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {

        Vector2 input = new Vector2(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        //bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedpercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);


        if(myslide.value == 0)
        {
            Application.LoadLevel(6);
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if ((col.gameObject.tag == "canavar"))
        {

            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.scream);

            Application.LoadLevel(6);


        }

       


        if ((col.gameObject.tag == "mantar"))
        {

            
            IncreaseTextUIScore("Point");



        }

        if ((col.gameObject.tag == "House"))
        {
            if (score >= target_score) {
                SoundManager.Instance.PlayOneShot(SoundManager.Instance.hoho);
                Application.LoadLevel(level);
            }
           
            
           



        }

       
    }

    public void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();
        score = int.Parse(textUIComp.text);
        score++;
        textUIComp.text = score.ToString();
    }


    public void runFunctionUp()
    {
        running = false;
    }
    public void runFunctionDown()
    {
        running = true;
    }
}

