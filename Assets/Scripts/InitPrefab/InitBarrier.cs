using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitBarrier : MonoBehaviour {

    public GameObject prefab;
    private float[] PosX = new float[] { -7.5f, 0f, 7.5f };
    private GameObject barrier;
    void Start () {
        for (int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.name == "Barricade(Clone)"|| transform.GetChild(i).gameObject.name == "BigStone(Clone)")
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        CloneBarrier();
    }

    void CloneBarrier()
    {
        //barrier = Instantiate(prefab, new Vector3(PosX[Random.Range(0, 3)], -1.55f, 0f), Quaternion.identity);
        //barrier.transform.SetParent(this.transform);
        barrier = Instantiate(prefab, this.transform);
        barrier.transform.position = new Vector3(PosX[Random.Range(0, 3)], -1.55f, 50f);
    }
	
	void Update () {
		
	}
}
