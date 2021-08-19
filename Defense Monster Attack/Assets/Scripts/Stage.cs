using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Stage : MonoBehaviour
{
    public TMP_Text number;
    public int stage;
    public bool checkLock;
    public int sceneOpened;//Scene đã được mở khóa
    public GameObject lockStage;

    // Start is called before the first frame update
    void Start()
    {
        stage =int.Parse(gameObject.name.Substring(2, 2)) - 9;
        number.text = stage.ToString();//Đánh số Stage tương ứng với Scene

        sceneOpened = PlayerPrefs.GetInt("SceneOpened");

        Debug.Log(PlayerPrefs.GetInt("SceneOpened"));
        //Unlock();
    }

    // Update is called once per frame
    void Update()
    {
        Unlock();
    }

    //Load Scene nếu màn chơi đã được mở khóa
    public void LoadScene()
    {
        if (checkLock == true)
        {
            SceneManager.LoadScene(stage);
        }
    }

    //Mở khóa Stage
    void Unlock()
    {
        if (stage <= sceneOpened)
        {
            checkLock = true;
            lockStage.SetActive(false);
        }
    }
}
