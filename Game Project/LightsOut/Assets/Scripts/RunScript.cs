using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunScript : MonoBehaviour
{


    UnityEngine.GameObject a;

    // Use this for initialization
    public void run()
    {
        a = GameObject.Find("PlayerController");    // game object crated

        // a.running = true;

    }
}