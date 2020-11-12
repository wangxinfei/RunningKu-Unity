using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OverPanel : MonoBehaviour {

    public static OverPanel instance;
    //public GameObject m_ScenePanel;
    private Button BtnResume;
    private Button BtnBack;
    private Text TxtContent;

    private void Awake()
    {
        instance = this;
        TxtContent = GameObject.Find("TxtContent").GetComponent<Text>();
        BtnResume = transform.Find("BtnResume").GetComponent<Button>();
        BtnBack = transform.Find("BtnBack").GetComponent<Button>();
    }

    void Start () {
        TxtContent.text = "您的成绩：" + GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().TxtTimer.text;
        BtnResume.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
            //m_ScenePanel.gameObject.SetActive(true);
            //Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        });
        BtnBack.onClick.AddListener(() => {
            this.gameObject.SetActive(false);
            //m_ScenePanel.gameObject.SetActive(true);
            SceneManager.LoadScene(Enum.GetName(typeof(SceneType), SceneType.Start));
            //Time.timeScale = 1;
        });
    }
	
	void Update () {
		
	}
}
