using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour {

    public GameObject go;
    public static StartPanel instance;
    private Button BtnEntry;

    private void Awake()
    {
        instance = this;
        BtnEntry = transform.Find("BtnEntry").GetComponent<Button>();
        //go = GameObject.Find("ScenePanel");
    }
    void Start () {
        BtnEntry.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
            go.SetActive(true);
        });
    }
	
	void Update () {
		
	}
}
