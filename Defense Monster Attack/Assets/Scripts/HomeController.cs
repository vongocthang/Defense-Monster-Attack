using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.SetInt("SceneOpened", 0);
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
}
