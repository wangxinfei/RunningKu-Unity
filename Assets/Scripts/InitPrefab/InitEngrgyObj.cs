using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitEngrgyObj : MonoBehaviour {

    private GameObject engrgyPrefab;
    private float[] PosX = new float[] { -7.5f, 0f, 7.5f };
    private GameObject engrgyObj;
    private Vector3 startEngrgyObjPos = new Vector3(0, 0, 50);
    private Vector3 initEngrgyObjPos;
    private Vector3 distanceOffset = new Vector3(0, 0, 25);
    //private int index = 1;
	void Start () {
        engrgyPrefab = Resources.Load("Prefabs/EngrgyObj") as GameObject;
        //print(GetInitEngrgyObjPos(5));
        for (int i = 1; i < 10; i++)
        {
            CloneEngrgyObj(i);
        }
	}
    /// <summary>
    /// 克隆恢复能量物体
    /// </summary>
    /// <param name="n"></param>
    public void CloneEngrgyObj(int n)
    {
        engrgyObj = Instantiate(engrgyPrefab, GetInitEngrgyObjPos(n) + new Vector3(PosX[Random.Range(0, 3)], 4f, 0), Quaternion.Euler(0, 0, 45));
        engrgyObj.transform.SetParent(this.transform);
    }
    /// <summary>
    /// 获得初始化恢复能量的位置点
    /// </summary>
    /// <param name="n">第N个</param>
    /// <returns></returns>
    Vector3 GetInitEngrgyObjPos(int n)
    {
        if (n == 1)
        {
            initEngrgyObjPos = (n - 1) * distanceOffset + startEngrgyObjPos;
        }
        if (n > 1)
        {
            initEngrgyObjPos = (n - 1) * distanceOffset + startEngrgyObjPos + GetInitEngrgyObjPos(n - 1);
        }
        return initEngrgyObjPos;
    }
	
	void Update () {
        //CloneEngrgyObj(index);
        //index++;
    }
}
