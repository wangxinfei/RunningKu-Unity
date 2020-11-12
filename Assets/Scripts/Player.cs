using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float Speed = 50;
    public float JumpSpeed = 5;
    public Text TxtCountTime;
    public Text TxtTimer;
    public Image EngrgySlider;
    public Image GoldSlider;
    public Image SliverSlider;
    public Image BronzeSlider;
    public GameObject m_OverPanel;
    private Animator animator;
    private Rigidbody rigbody;
    private Transform followCam;
    private Vector3 startPos;
    //private Quaternion startAngle;
    private Vector3 offset;
    private float time = 4;
    private float startTime = 0;
    private bool IsGround = false;
    private float silverTime = 0;
    private float goldTime = 0;
    private float bronzeTime = 0;
    private bool State = false;
    private bool isJump = false;
    private bool flag = true;
    //private int JumpCount = 0;
	void Start () {
        InitScene();
    }
	
	void Update () {
        if (flag)
        {
            CountDownTime();
            CountDownTimeOfMedal();
            if (Input.GetKeyDown(KeyCode.W))
            {
                animator.SetBool("IsRun", true);
                //animator.SetFloat("RotateSpeed", 0);
                if (IsGround == true)
                {
                    //animator.SetBool("Jump", true);    执行跳的动画
                    isJump = true;
                    //JumpCount++;
                }
                IsGround = false;
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (transform.position.x > -1)
                {
                    transform.position -= Vector3.right * 7.5f;
                    //animator.SetFloat("FowardSpeed", 1);
                    //animator.SetFloat("RotateSpeed", -1);
                    //print("左" + transform.position);
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (transform.position.x < 1)
                {
                    transform.position += Vector3.right * 7.5f;
                    //animator.SetFloat("FowardSpeed", 1);
                    //animator.SetFloat("RotateSpeed", 1);
                    //print("右" + transform.position);
                }
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
            if (transform.position.y < -10f)
            {
                GameOver();
            }
            if (isJump)
            {
                PlayJump();
            }
            if (transform.position.y > 0.1f)
            {
                animator.SetBool("IsRun", false);
                float y = transform.position.y - 0.4f;
                transform.position = new Vector3(transform.position.x, y, transform.position.z);
            }
            else
            {
                //animator.SetBool("IsRun", true);
                IsGround = true;
            }
        }
    }

    private void LateUpdate()
    {
        //followCam.transform.position = transform.position + offset;
        //Quaternion qu = Quaternion.LookRotation(transform.position - followCam.transform.position);
        //followCam.transform.rotation = Quaternion.Slerp(followCam.transform.rotation, qu, Time.deltaTime * 20f);
    }

    private void FixedUpdate()
    {
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    animator.SetBool("IsRun", true);
        //    if(IsGround == true)
        //    {
        //        //animator.SetBool("Jump", true);    执行跳的动画
        //        PlayJump();
        //    }
        //}
    }

    void PlayJumpCount()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && JumpCount <= 1)
        //{
        //    PlayJump();
        //    JumpCount++;
        //}
    }

    void PlayJump()
    {
        //添加加速度
        //rigbody.velocity += new Vector3(0, 10, 0);
        ////给物体添加一个向上的力
        //rigbody.AddForce(1.5f * Vector3.up * Time.deltaTime);
        if (transform.position.y < 10f)
        {
            float y = transform.position.y + 1.2f;
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        else
        {
            isJump = false;
        }
    }
    /// <summary>
    /// 能量显示
    /// </summary>
    void EngrgyShow()
    {
        EngrgySlider.GetComponent<Slider>().value -= 0.05f * Time.deltaTime;
        EngrgySlider.GetComponentInChildren<Text>().text = ((int)(EngrgySlider.GetComponent<Slider>().value * 100f)).ToString();
        if (EngrgySlider.GetComponent<Slider>().value == 0)
        {
            GameOver();
        }
    }
    /// <summary>
    /// 计时器
    /// </summary>
    void CountTimer()
    {
        if ((int)startTime / 60 < 10)
        {
            if((int)startTime % 60 < 10)
            {
                TxtTimer.text = "0" + ((int)startTime / 60).ToString() + ": 0" + ((int)startTime % 60).ToString();
            }
            else if((int)startTime % 60 < 60)
            {
                TxtTimer.text = "0" + ((int)startTime / 60).ToString() + ": " + ((int)startTime % 60).ToString();
            }
        }
        else if ((int)startTime / 60 < 60)
        {
            if ((int)startTime % 60 < 10)
            {
                TxtTimer.text = ((int)startTime / 60).ToString() + ": 0" + ((int)startTime % 60).ToString();
            }
            else if ((int)startTime % 60 < 60)
            {
                TxtTimer.text = ((int)startTime / 60).ToString() + ": " + ((int)startTime % 60).ToString();
            }
        }
    }
    /// <summary>
    /// 倒计时
    /// </summary>
    void CountDownTime()
    {
        time -= Time.deltaTime;
        TxtCountTime.text = ((int)time).ToString();
        if (time < 1)
        {
            animator.SetBool("IsRun", true);
        }
        if ((int)time <= 0)
        {
            PlayerMove();
            startTime += Time.deltaTime;
            TxtCountTime.gameObject.SetActive(false);
            CountTimer();
            if (startTime > 1)
            {
                EngrgyShow();
            }
        }
    }
    /// <summary>
    /// 人物移动
    /// </summary>
    void PlayerMove()
    {
        animator.SetBool("IsRun", true);
        //animator.SetFloat("RotateSpeed", 0);
        transform.Translate(Speed * transform.forward * Time.deltaTime);

        //float angle = Vector3.Angle(followCam.forward, transform.forward);
        //Quaternion quater = Quaternion.LookRotation(followCam.forward);
        //followCam.rotation = Quaternion.Slerp(followCam.rotation, quater, Time.deltaTime * 1f);
        //followCam.Translate(Speed * transform.forward * Time.deltaTime);
        //Quaternion quater = Quaternion.LookRotation(transform.position - followCam.position);
        //followCam.rotation = Quaternion.Slerp(followCam.rotation, quater, Speed * Time.deltaTime);
    }

    string GetDurationTime(ProperType type)
    {
        ConfigManager.Instance().LoadTxt();
        return ((PropertyIntroducion)ConfigManager.Instance().GetConfigData(RunningConfigType.PropertyIntroducion))
            .GetConfigItemData(Enum.GetName(typeof(ProperType), type)).DurationTime;
    }

    void CountDownTimeOfMedal()
    {
        GoldMedalDownTime();
        SilverMedalDownTime();
        BronzeMedalDownTime();
    }

    void GoldMedalDownTime()
    {
        if (goldTime > 0)
        {
            goldTime -= 0.1f * Time.deltaTime;
            GoldSlider.GetComponent<Slider>().value = goldTime;
            GoldSlider.GetComponentInChildren<Text>().text = ((int)(goldTime * 10f)).ToString();
            //增加左右移动灵敏度，持续6秒
            //设置左右移动灵敏度
        }
        else
        {
            //设置为原来的左右灵敏度
        }
    }

    void SilverMedalDownTime()
    {
        if (silverTime > 0)
        {
            silverTime -= 0.1f * Time.deltaTime;
            SliverSlider.GetComponent<Slider>().value = silverTime;
            SliverSlider.GetComponentInChildren<Text>().text = ((int)(silverTime * 10f)).ToString();
            //增加跳跃高度，持续8秒
            JumpSpeed = 10;
        }
        else
        {
            JumpSpeed = 5;
        }
    }

    void BronzeMedalDownTime()
    {
        if (bronzeTime > 0)
        {
            bronzeTime -= 0.1f * Time.deltaTime;
            BronzeSlider.GetComponent<Slider>().value = bronzeTime;
            BronzeSlider.GetComponentInChildren<Text>().text = ((int)(bronzeTime * 10f)).ToString();
            //增加奔跑速度，持续10秒
            Speed = 80;
        }
        else if (State)
        {
            Speed = 10f;
        }
        else
        {
            Speed = 50;
            //BronzeSlider.GetComponent<Slider>().value = bronzeTime;
            //BronzeSlider.GetComponentInChildren<Text>().text = ((int)(bronzeTime * 10f)).ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "EngrgyObj(Clone)")
        {
            //能量饮料
            //恢复全部能量
            if (EngrgySlider.GetComponent<Slider>().value == 0)
            {
                //animator.SetBool("IsLose", true);
                GameOver();
            }
            else
            {
                other.gameObject.SetActive(false);
                EngrgySlider.GetComponentInChildren<Text>().text = "100";
                EngrgySlider.GetComponent<Slider>().value = 1;
            }
            //如果能量为0，或主角奔跑过程中碰到障碍时游戏结束
        }
        if (other.gameObject.name == "GoldMedal(Clone)")
        {
            goldTime = 0.6f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "SilverMedal(Clone)")
        {
            silverTime = 0.8f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "BronzeMedal(Clone)")
        {
            bronzeTime = 1f;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "Mystical(Clone)")
        {
            //神秘道具
            //获得以上所有效果，持续10秒
            other.gameObject.SetActive(false);
            EngrgySlider.GetComponentInChildren<Text>().text = "100";
            EngrgySlider.GetComponent<Slider>().value = 1;
            goldTime = 1f;
            silverTime = 1f;
            bronzeTime = 1f;
        }

        //沙坑
        if (other.gameObject.name == "Sandpit")
        {
            State = true;
            bronzeTime = 0;
        }
        //坑
        //if (other.gameObject.name == "Pit")
        //{
        //    //游戏结束
        //    GameOver();
        //}
        //泥泞道路
        if (other.gameObject.name == "MuddyRoad")
        {
            State = true;
            bronzeTime = 0;
        }
        //独木桥
        if (other.gameObject.name == "Bridge(Clone)")
        {
            //游戏结束
            GameOver();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //沙坑
        if (other.gameObject.name == "Sandpit")
        {
            State = false;
            //bronzeTime = 0;
        }
        //泥泞道路
        if (other.gameObject.name == "MuddyRoad")
        {
            State = false;
            bronzeTime = 0;
            //Speed = 50f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //落地检测
        if (collision.collider.tag == "Ground")
        {
            //animator.SetBool("Jump", false);    跳跃的动画
            IsGround = true;
            print("落地检测");
        }

        //110跨栏
        if (collision.collider.tag == "Hurdles")
        {
            //游戏结束
            GameOver();
        }
        //路障
        if (collision.collider.name == "Barricade(Clone)")
        {
            //游戏结束
            GameOver();
        }
        
        //大块石头
        if (collision.collider.name == "BigStone(Clone)")
        {
            //游戏结束
            GameOver();
        }
        
    }    

    void GameOver()
    {
        flag = false;
        Invoke("ShowOverPanel", 1f);
    }

    void ShowOverPanel()
    {
        m_OverPanel.gameObject.SetActive(true);
    }

    void InitScene()
    {
        animator = GetComponent<Animator>();
        rigbody = GetComponent<Rigidbody>();
        followCam = GameObject.Find("FollowCam").transform;
        startPos = followCam.transform.position;
        //startAngle = followCam.transform.rotation;
        offset = transform.position - startPos;
    }

    void FollowPlayer()
    {
        followCam.transform.position = transform.position + offset;
        Quaternion qu = Quaternion.LookRotation(transform.position - followCam.transform.position);
        followCam.transform.rotation = Quaternion.Slerp(followCam.transform.rotation, qu, Time.deltaTime * 20f);
    }
}
