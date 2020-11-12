using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHelp : MonoBehaviour {

    private Button TabOperation;
    private Button TabIntroduce;
    private Button BtnClose;
    private Text TxtContent;

    private void Awake()
    {
        TabOperation = GameObject.Find("TabOperation").GetComponent<Button>();
        TabIntroduce = GameObject.Find("TabIntroduce").GetComponent<Button>();
        BtnClose = transform.Find("BtnClose").GetComponent<Button>();
        TxtContent = transform.Find("TabContent").GetComponent<Text>();
    }

    void Start () {
        TxtContent.text = ConfigManager.Instance().GetConfigContent(RunningConfigType.PlayerOperation).ToString();
        TabOperation.onClick.AddListener(() => {
            TxtContent.text = ConfigManager.Instance().GetConfigContent(RunningConfigType.PlayerOperation).ToString();
        });
        TabIntroduce.onClick.AddListener(() => {
            TxtContent.text = ConfigManager.Instance().GetConfigContent(RunningConfigType.PropertyIntroduce).ToString();
        });
        BtnClose.onClick.AddListener(() => {
            gameObject.SetActive(false);
            //Time.timeScale = 1;
        });
    }
	
	void Update () {
		
	}
}
