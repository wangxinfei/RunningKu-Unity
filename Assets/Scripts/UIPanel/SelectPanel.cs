using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectPanel : MonoBehaviour {

    private Button BtnStart;
    private Button BtnSelect;
    private Button BtnPause;
    private Button BtnHelp;
    private Button BtnOver;
    public GameObject m_ScenePanel;
    public GameObject m_HelpPanel;

    private void Awake()
    {
        BtnStart = transform.Find("BtnStart").GetComponent<Button>();
        BtnSelect = transform.Find("BtnSelect").GetComponent<Button>();
        BtnPause = transform.Find("BtnPause").GetComponent<Button>();
        BtnHelp = transform.Find("BtnHelp").GetComponent<Button>();
        BtnOver = transform.Find("BtnOver").GetComponent<Button>();
    }

    void Start () {
        BtnStart.onClick.AddListener(BtnStartOnClick);
        BtnSelect.onClick.AddListener(BtnSelectOnClick);
        BtnPause.onClick.AddListener(BtnPauseOnClick);
        BtnHelp.onClick.AddListener(BtnHelpOnClick);
        BtnOver.onClick.AddListener(BtnOverOnClick);
    }

    private void BtnOverOnClick()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void BtnPauseOnClick()
    {
        Time.timeScale = 0;
    }

    private void BtnHelpOnClick()
    {
        m_ScenePanel.SetActive(false);
        m_HelpPanel.SetActive(true);
    }

    private void BtnSelectOnClick()
    {
        m_HelpPanel.SetActive(false);
        m_ScenePanel.SetActive(true);
    }

    private void BtnStartOnClick()
    {
        SceneManager.LoadScene(Enum.GetName(typeof(SceneType), ScenePanel.instance.panel));
        //print(Enum.GetName(typeof(SceneType), ScenePanel.instance.panel));
    }

    void Update () {
		
	}
}
