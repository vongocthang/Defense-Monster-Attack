using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Monster : MonoBehaviour
{
    float timeLine;//Mốc thời gian xuất hiện
    public MonsterInfor infor;
    public TMP_Text health;
    int count;
    public int damge;
    Collider2D cd;
    float moveSpeed;
    public ParticleSystem psDie;
    bool dead = false;

    //public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        timeLine = Time.time;
        health.text = infor.health.ToString();
        count = infor.health;
        damge = infor.damge;
        cd = GetComponent<Collider2D>();
        moveSpeed = infor.speed;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Health();
        Die();
    }

    //
    void Move()
    {
        //Độ trễ cho đến khi bắt đầu di chuyển
        if (Time.time > timeLine + 1)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Arrow")
        {
            count -= 1;
            damge = count;
            Debug.Log("Trung ten");
        }
    }

    //Đi qua cổng dưới thì hủy
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Gate")
        {
            Destroy(gameObject);
        }
    }

    //
    void Health()
    {
        health.transform.position = Camera.main.WorldToScreenPoint(transform.position +
            new Vector3(0.5f, 0, 0));
        health.text = count.ToString();
    }

    //
    void Die()
    {
        if (count == 0)
        {


            moveSpeed = 0;
            cd.enabled = false;
            if (dead == false)
            {
                Instantiate(psDie, transform.position, psDie.transform.rotation);
            }
            dead = true;

            StartCoroutine(WaiteForDestroy());
            
        }
    }

    IEnumerator WaiteForDestroy()
    {
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }
}
