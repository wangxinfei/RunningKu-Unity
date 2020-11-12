using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helping : MonoBehaviour {

    public GameObject m_GameHelp;
    private Button BtnHelp;

    private void Awake()
    {
        BtnHelp = transform.Find("BtnHelp").GetComponent<Button>();
    }

    void Start () {
        BtnHelp.onClick.AddListener(() => {
            m_GameHelp.SetActive(true);
            //Time.timeScale = 0;
        });
    }
	
	void Update () {
		
	}
}
