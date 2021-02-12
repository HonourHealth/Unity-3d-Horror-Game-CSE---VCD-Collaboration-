using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.Rotate(0, 0, 90 * 2*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Sam-Kid")
        {
            other.GetComponent<PlayerController>().IncreaseTextUIScore("Point");
            Destroy(gameObject);
        }
 
    }
}
