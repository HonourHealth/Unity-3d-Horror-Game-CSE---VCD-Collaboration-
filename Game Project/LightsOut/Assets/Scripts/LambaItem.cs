using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LambaItem : MonoBehaviour {

    public Light mylight;

    public int angle;
    public int intens;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.Rotate(0, 90 * 2*Time.deltaTime, 90 * 2*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sam-Kid")
        {
            mylight.spotAngle = angle;
            mylight.intensity = intens;
            Destroy(gameObject);
        }
    }
}
