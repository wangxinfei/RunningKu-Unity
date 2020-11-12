using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumePanel : MonoBehaviour {

    public static ResumePanel instance;
    public GameObject m_PausePanel;
    private Button BtnPause;
    private Button BtnReSume;
    private Button BtnExit;

    private void Awake()
    {
        instance = this;
        BtnPause = transform.Find("BtnPause").GetComponent<Button>();
        BtnReSume = transform.Find("BtnResume").GetComponent<Button>();
        BtnExit = transform.Find("BtnExit").GetComponent<Button>();
    }

    void Start () {
        BtnPause.onClick.AddListener(() => {
            Time.timeScale = 0;
            BtnPause.gameObject.SetActive(false);
            BtnReSume.gameObject.SetActive(true);
        });
        BtnReSume.onClick.AddListener(() => {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            m_PausePanel.gameObject.SetActive(true);
        });
        BtnExit.onClick.AddListener(() => {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        });
    }
	
	void Update () {
		
	}
}
