using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGroundMap : MonoBehaviour {

    public Transform[] planeList;
    //距离
    private float speed = 100f;
    //队列
    private Queue<Transform> queueList;
    private bool init = false;
	void Start () {
		
	}
	
	void Update () {
        AddQueueList();
    }

    void AddQueueList()
    {
        if (!init)
        {
            queueList = new Queue<Transform>();
            init = true;
            for (int i = 0; i < planeList.Length; i++)
            {
                //进队列，实例化
                Transform plane = Instantiate(planeList[Random.Range(0, planeList.Length)], new Vector3(1, 0, speed * i), Quaternion.Euler(0, 90, 0));
                //入队
                queueList.Enqueue(plane);
            }
        }
        if(this.transform.position.x - queueList.Peek().position.x >= 99f)
        {
            //出队
            Transform plane1 = queueList.Dequeue();
            plane1.position = new Vector3(1, 0, queueList.ToArray()[queueList.Count - 1].position.z + 99);
            queueList.Enqueue(plane1);
        }
    }
}
