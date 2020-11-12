using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyPanel : MonoBehaviour {

    public static PropertyPanel instance;
    private Button BtnClose;
    private Text TxtContent;
    private RunningConfigType runningConfigType = RunningConfigType.PropertyIntroduce;

    private void Awake()
    {
        instance = this;
        TxtContent = transform.Find("TxtContent").GetComponent<Text>();
        BtnClose = transform.Find("BtnClose").GetComponent<Button>();
    }


    void Start()
    {
        TxtContent.text = ConfigManager.Instance().GetConfigContent(runningConfigType).ToString();
        BtnClose.onClick.AddListener(() => { this.gameObject.SetActive(false); });
    }

    void Update () {
		
	}
}
