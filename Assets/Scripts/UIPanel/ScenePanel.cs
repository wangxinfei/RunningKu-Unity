using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenePanel : MonoBehaviour {

    public static ScenePanel instance;
    public SceneType panel = SceneType.Start;
    private Button BtnUp;
    private Button BtnDown;
    private Image SceneImg;
    private Text TxtSceneName;
    private Button BtnStart;
    private Sprite[] list;
    private int index = 0;
    private const string Path = "SceneImgs/";

    private void Awake()
    {
        instance = this;
        BtnUp = transform.Find("BtnUp").GetComponent<Button>();
        BtnDown = transform.Find("BtnDown").GetComponent<Button>();
        SceneImg = transform.Find("SceneImg").GetComponent<Image>();
        TxtSceneName = GameObject.Find("TxtSceneName").GetComponent<Text>();
        BtnStart = transform.Find("BtnStart").GetComponent<Button>();
    }

    public void ShowPanel()
    {
        this.gameObject.SetActive(true);
    }

    void Start () {
        list = Resources.LoadAll<Sprite>(Path);
        ShowSceneImage();
        BtnUp.onClick.AddListener(() => {
            //panel = SceneType.PlayGround;
            index--;
            if (index < 0)
            {
                index = list.Length - 1;
            }
            ShowSceneImage();
        });
        BtnDown.onClick.AddListener(() => {
            //panel = SceneType.Malathion;
            index++;
            if (index > list.Length - 1)
            {
                index = 0;
            }
            ShowSceneImage();
        });
        BtnStart.onClick.AddListener(() => {
            SceneManager.LoadScene(Enum.GetName(typeof(SceneType), panel));
            //print(panel);
            //SceneManager.LoadScene("PlayGround");
        });
    }

    void ShowSceneImage()
    {
        //SceneImg.sprite= Resources.Load<Sprite>(Path + index);
        SceneImg.sprite = list[index];
        //print(SceneImg.sprite);
        TxtSceneName.text = SceneImg.sprite.name.ToString();
        panel = (SceneType)Enum.Parse(typeof(SceneType), TxtSceneName.text);
    }
	
	void Update () {
		
	}
}
