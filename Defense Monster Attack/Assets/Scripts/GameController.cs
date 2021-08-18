using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] gate;//Cổng bên dưới/cần bảo vệ
    public GameObject gameOver;//UI
    public GameObject complete;//UI
    public float timeFinish;//Thời gian giới hạn của màn chơi
    public bool play;//Kiểm tra đã ấn nút Start
    public float timeStart;//Mốc thời gian bắt đầu chơi
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("SceneOpened"));

        SceneOpened();

        gate = GameObject.FindGameObjectsWithTag("Gate");

        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.SetActive(false);

        complete = GameObject.FindGameObjectWithTag("Complete");
        complete.SetActive(false);

        player = GameObject.Find("Player").GetComponent<Player>();
        player.enabled = false;
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
        GameOver();
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
            }
        }
    }

    //Sau bao nhiêu lần ngập hành thì cũng thắng được trận
    void Complete()
    {

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
    }

    //Ok rồi chơi tiếp
    public void Resume()
    {
        Time.timeScale = 1f;
    }

    //Bắt đầu chơi
    public void StartGame()
    {
        play = true;
        timeStart = Time.time;
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
}
