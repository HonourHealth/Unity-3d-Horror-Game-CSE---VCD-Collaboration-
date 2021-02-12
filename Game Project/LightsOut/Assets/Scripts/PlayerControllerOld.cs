using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerOld : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;


    int score = 0;
    Vector2 input;
    int flag = 1;


    Animator animator;
    Transform cameraT;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {


        input = new Vector2(Input.GetAxisRaw("Horizontal") * flag, Input.GetAxisRaw("Vertical") * flag);

       

        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude*flag;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedpercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);



    }

    void OnCollisionEnter(Collision col)
    {
        

       if ((col.gameObject.tag == "canavar"))
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.hoho);




        }

       




        if ((col.gameObject.tag == "House"))
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.finish);




        }
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();
        score = int.Parse(textUIComp.text);
        score++;
        textUIComp.text = score.ToString();
    }

    IEnumerator Flag_wait(float time)
    {


        yield return new WaitForSeconds(time);
        flag = 1;
        walkSpeed = 2f;
        runSpeed = 6f;
    }
}

