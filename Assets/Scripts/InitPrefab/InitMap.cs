using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMap : MonoBehaviour {

    public GameObject env;
    public GameObject[] planeList;
    private GameObject planePrefab;
    private GameObject player;
	void Start () {
        //print();
    }
	
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            planePrefab = Instantiate(planeList[Random.Range(0, planeList.Length)], new Vector3(0, 0, 400f + other.transform.position.z), Quaternion.Euler(0, 0, 0));
            planePrefab.transform.SetParent(env.transform);
        }
        for (int i = 5; i < env.transform.childCount; i++)
        {
            if (env.transform.GetChild(i).transform.position.z + 350 < other.transform.position.z)
            {
                Destroy(env.transform.GetChild(i).gameObject);
            }
        }
    }

}
