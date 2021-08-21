﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    GameObject[] gate;//Cổng bên dưới/cần bảo vệ
    public GameObject gameOver;//UI
    public GameObject complete;//UI
    public float timeFinish;//Thời gian giới hạn của màn chơi
    float countTime;//Đếm thời gian
    bool play;//Kiểm tra đã ấn nút Start
    float timeStart;//Mốc thời gian bắt đầu chơi
    Player player;
    public Slider timeBar;//Hiển thị thời gian giới hạn của màn chơi
    public TMP_Text level;//Hiển thị cấp độ màn chơi

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt("SceneOpened"));
        //
        SceneOpened();
        //
        gate = GameObject.FindGameObjectsWithTag("Gate");
        ////
        //gameOver = GameObject.FindGameObjectWithTag("GameOver");
        //gameOver.SetActive(false);
        ////
        //complete = GameObject.FindGameObjectWithTag("Complete");
        //complete.SetActive(false);
        //Không xài Find() vì nó nặng nếu muốn phát triển game hơn nữa 
        GameObject[] a = GameObject.FindGameObjectsWithTag("Player");
        player = a[0].GetComponent<Player>();
        player.enabled = false;
        //Hiển thị thời gian giới hạn
        timeBar.maxValue = timeFinish;
        timeBar.value = timeFinish;
        countTime = timeFinish;
        //
        level.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    //Lưu màn chơi được mở khóa mới nhất
    void SceneOpened()
    {
        int so = PlayerPrefs.GetInt("SceneOpened");
        //Debug.Log(so);
        if (so < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("SceneOpened", SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowLimitedTime();

        GameOver();

        Complete();
    }

    //Nước mắt đã rơi-trò chơi kết thúc
    void GameOver()
    {
        for(int i=0; i<gate.Length; i++)
        {
            Gate g = gate[i].GetComponent<Gate>();
            if (g.count <= 0)
            {
                gameOver.SetActive(true);
                play = false;
            }
        }
    }

    //Sau bao nhiêu lần ngập hành thì cũng thắng được trận
    void Complete()
    {
        if (play == true)
        {
            if (countTime <= 0)
            {
                complete.SetActive(true);
            }
        }
    }

    //Trở về nhà
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    //Tý nữa là thắng rồi, cho thử lại đê
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Màn tiếp theo đi bạn êiii, game dễ vãi lol
    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Dừng lại nghỉ tý đeeeeeee
    public void Pause()
    {
        Time.timeScale = 0f;
        play = false;
    }

    //Ok rồi chơi tiếp
    public void Resume()
    {
        Time.timeScale = 1f;
        play = true;
    }

    //Bắt đầu chơi từ màn mới nhất đã mở khóa
    public void StartGame()
    {
        play = true;
        timeStart = Time.time;//Mốc thời gian bắt đầu chơi
    }

    //Mở khóa hành động bắn tên
    public void EnabledPlayer()
    {
        player.enabled = true;
    }

    //Dừng hành động bắn tên
    public void StopPlayer()
    {
        player.enabled = false;
    }

    void ShowLimitedTime()
    {
        if (play == true)
        {
            countTime = timeFinish + timeStart - Time.time;
            timeBar.value = countTime;
        }
    }
}
