using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6;
    public int monster_border;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    Animator animator;
    Transform cameraT;
    public GameObject player;
    Vector2 input;

    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    void Update()
    {


        


        if (player.transform.position.x > transform.position.x)
        {
            if (player.transform.position.z > transform.position.z)
            {
                input = new Vector2(1, 1);
            }
            else if (player.transform.position.z < transform.position.z)
            {

                input = new Vector2(1, -1);
            }

        }

        else if (player.transform.position.x < transform.position.x)
        {
            if (player.transform.position.z > transform.position.z)
            {
                input = new Vector2(-1, 1);
            }
            else if (player.transform.position.z < transform.position.z)
            {

                input = new Vector2(-1, -1);
            }

        }

        if (player.transform.position.x - transform.position.x < monster_border && player.transform.position.x - transform.position.x >monster_border*-1)
        {
            if (player.transform.position.z - transform.position.z < monster_border && player.transform.position.z - transform.position.z > monster_border*-1)
            {

                SoundManager.Instance.PlayOneShot(SoundManager.Instance.monster_is_coming);
            }
            

        }

        Vector2 inputDir = input.normalized;
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedpercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }
}

