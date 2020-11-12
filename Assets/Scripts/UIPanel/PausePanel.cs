using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour {

    public static PausePanel instance;
    public GameObject m_ResumePanel;
    private Button BtnPause;

    private void Awake()
    {
        instance = this;
        BtnPause = transform.Find("BtnPause").GetComponent<Button>();
    }

    void Start () {
        BtnPause.onClick.AddListener(() => {
            Time.timeScale = 0;
            this.gameObject.SetActive(false);
            m_ResumePanel.SetActive(true);
        });
    }
	
	void Update () {
		
	}
}
