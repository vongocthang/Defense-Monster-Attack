using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    GameObject[] monster1;
    GameObject[] monster2;
    GameObject[] monster3;
    GameObject[] monster4;
    GameObject[] monster5;
    public float[] createTime;//Mốc thời gian tạo quái vật tại cổng
    public int[] callMonster;//Loại quái vật sẽ tạo-cấp bậc
    int count = 0;//Đếm số điểm/máu còn lại
    GameObject clone;
    float timeStart;//Thời gian bắt đầu chơi/ấn nút Start
    bool play;//Kiểm tra đã ấn nút Start

    // Start is called before the first frame update
    void Start()
    {
        monster1 = GameObject.FindGameObjectsWithTag("Monster1");
        monster2 = GameObject.FindGameObjectsWithTag("Monster2");
        monster3 = GameObject.FindGameObjectsWithTag("Monster3");
        monster4 = GameObject.FindGameObjectsWithTag("Monster4");
        monster5 = GameObject.FindGameObjectsWithTag("Monster5");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartGame();

        Create();

        StopCreate();
    }

    //Quái vật được tạo vào mốc thời gian (và cấp độ) được thiết lập cho mỗi màn chơi
    //Độ khó tăng dần
    void Create()
    {
        //Ấn nút Start thì quái vật mới bắt đầu xuất hiện từ cổng
        if (play == true)
        {
            for (int i = 0; i < createTime.Length; i++)
            {
                if (Time.time >= createTime[i] + timeStart && i == count)
                {
                    //Chọn ngẫu nhiên trong 4 quái vật
                    switch (callMonster[i])
                    {
                        case 1:
                            GameObject m1 = monster1[Random.Range(0, 3)];
                            clone = Instantiate(m1, transform.position,
                                m1.transform.rotation);
                            clone.GetComponent<Monster>().enabled = true;
                            break;
                        case 2:
                            GameObject m2 = monster2[Random.Range(0, 3)];
                            clone = Instantiate(m2, transform.position,
                                m2.transform.rotation);
                            clone.GetComponent<Monster>().enabled = true;
                            break;
                        case 3:
                            GameObject m3 = monster3[Random.Range(0, 3)];
                            clone = Instantiate(m3, transform.position,
                                m3.transform.rotation);
                            clone.GetComponent<Monster>().enabled = true;
                            break;
                        case 4:
                            GameObject m4 = monster4[Random.Range(0, 3)];
                            clone = Instantiate(m4, transform.position,
                                m4.transform.rotation);
                            clone.GetComponent<Monster>().enabled = true;
                            break;
                        case 5:
                            GameObject m5 = monster5[Random.Range(0, 3)];
                            clone = Instantiate(m5, transform.position,
                                m5.transform.rotation);
                            clone.GetComponent<Monster>().enabled = true;
                            break;
                    }
                    count++;
                }
            }
        }
    }

    //Kết thúc tạo quái vật
    void StopCreate()
    {
        if (count > createTime.Length)
        {
            StartCoroutine(DestroyGate());
        }
    }

    //
    IEnumerator DestroyGate()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    //Thời gian bắt đầu chơi
    void StartGame()
    {
        play = GameObject.Find("Main UI").GetComponent<GameController>().play;
        timeStart = GameObject.Find("Main UI").GetComponent<GameController>().timeStart;
    }
}
