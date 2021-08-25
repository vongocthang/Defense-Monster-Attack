using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public GameObject musicON;
    public GameObject musicOFF;

    // Start is called before the first frame update
    void Start()
    {
        SetupAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Chơi màn mới nhất
    public void StartGame()
    {
        //Nếu là lần đầu chơi, load scene số 1
        if(PlayerPrefs.GetInt("SceneOpened") == 0)
        {
            SceneManager.LoadScene(1);
            
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneOpened"));
        }
    }

    //Cài đặt nhạc nền-âm thanh
    void SetupAudio()
    {
        if (PlayerPrefs.GetString("Music") == "off")
        {
            //GetComponent<AudioSource>().Stop();
            musicOFF.SetActive(true);
            musicON.SetActive(false);
        }
        else
        {
            //GetComponent<AudioSource>().Play();
            musicOFF.SetActive(false);
            musicON.SetActive(true);
        }
    }

    //Bật tắt nhạc nền
    public void CheckAudio(string check)
    {
        PlayerPrefs.SetString("Music", check);
    }
}
