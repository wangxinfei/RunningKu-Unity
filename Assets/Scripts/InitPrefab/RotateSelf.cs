using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSelf : MonoBehaviour {

	void Start () {
		
	}

	void Update () {
        //transform.Rotate(Vector3.up, 30 * Time.deltaTime);
        transform.Rotate(transform.up, 30 * Time.deltaTime);
    }
}
