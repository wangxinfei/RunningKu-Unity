using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMedal : MonoBehaviour {

    public GameObject[] GamePrefabs;
    private float[] PosX = new float[] { -7.5f, 0f, 7.5f };
    private Vector3 InitPos;
    private Vector3 StartPos = new Vector3(0, 0, 60);
    private GameObject Medal;

    void Start () {
        for (int i = 1; i < 100; i++)
        {
            CloneMedal(i);
            //print(GetInitMedalPos(i));
        }
    }

    Vector3 GetInitMedalPos(int n)
    {
        if (n == 1)
        {
            InitPos = StartPos;
        }
        if (n > 1)
        {
            InitPos = GetInitMedalPos(n - 1) + StartPos;
        }
        return InitPos;
    }

    GameObject CloneMedal(int n)
    {
        //Medal = Instantiate(GamePrefabs[Random.Range(0, GamePrefabs.Length)], this.transform) as GameObject;
        Medal = Instantiate(GamePrefabs[Random.Range(0, GamePrefabs.Length)], GetInitMedalPos(n) + new Vector3(PosX[Random.Range(0, 3)], 4f, 0), Quaternion.Euler(0, 45, 90)) as GameObject;
        Medal.transform.SetParent(this.transform);
        return Medal;
    }

    GameObject CloneMedal(GameObject prefab)
    {
        GameObject GO = Instantiate(prefab, transform);
        return GO;
    }
	
	void Update () {
		
	}
}
