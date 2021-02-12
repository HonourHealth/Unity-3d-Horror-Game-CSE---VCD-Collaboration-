using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stupid : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;
    public float x_right;
    public float x_left;
    public float z_up;
    public float z_down;
    public int motion_type; // bu değişkende hereketimiz  yataysa 0 dikeyse 1 olsun deriz

    float turnSmoothVelocity;
    public int flag = 0;

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
        if (motion_type == 0)
        { //hareket yatayda olacak

            if (transform.position.x > x_right)
            {
                flag = -1;
            }

            else if (transform.position.x < x_left)
            {
                flag = 1;
            }

            input = new Vector2(flag, 0);
        }


        else if (motion_type == 1)
        {

            if (transform.position.z > z_up)
            {
                flag = -1;
            }

            else if (transform.position.z < z_down)
            {
                flag = 1;
            }

            input = new Vector2(0, flag);
        }



        Vector2 inputDir = input.normalized;
        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, 0);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, 0);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedpercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

    }
}

/* Sorunlar neydi ve nasıl çözüldüler? 
 * 
 * 1) Vector2 input ; update'in içinde tanımlanmıştı.Onu yukarda tanımlayınca ; ilk değer atmaya gerek kalmadı.
 * 
 * 2) turnSmoothTime değişkeni problem yaratıyordu;mesela x ekseninde hareket ediyoruz diyelim; bu değişken yüzünden canavar z ekseninde sürekli sapma gösteriyordu.Bu değişkeni sildim ve
 *   transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, 0); içinde onun olduğu yere 0 yazdım.Şimdi yine z'de sapma
 *   oluyor ama hareket yönü değişince eski haline geliyor.
 * 
 * 3) Son olarak kod hem yatayda hem dikeyde harekete uyum sağlayabilecek hale getirildi.Olay şu; belli public değişkenler tanımladım ve bunları Unity içersinde değiştirerek hareketin
 * yatayda mı düşeyde mi olacağını belirttim.Ayrıca kafamızda oluşturduğumuz sanal sınırları da public değişkenlerle ifade edip yine Unity içersinde atadım.Hareket yönünü belirten 
 * Flag değerini başlangıçta sağa(ya da yukarıya) gitmek istiyorsak 1 ; sola(ya da aşağıya) gitmek istiyorsak -1 olarak ayarlamalıyız.Eğer 0 atarsak hiçbir hareket olmuyor haliyle.
 * 
 * 
 */
