using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gate : MonoBehaviour
{
    public MonsterInfor infor1;
    public MonsterInfor infor2;
    public MonsterInfor infor3;
    public MonsterInfor infor4;
    public MonsterInfor infor5;
    public TMP_Text health;//Hiển thị điểm/máu còn lại
    public int count;//Đếm số điểm/máu
    Monster monster;//Damge của quái vật=máu hiện tại của nó
    public ParticleSystem hitDamge;

    // Start is called before the first frame update
    void Start()
    {
        health.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.tag == "Monster1" || other.tag == "Monster2" || other.tag == "Monster3" ||
    //        other.tag == "Monster4" || other.tag == "Monster5")
    //    {
    //        Instantiate(hitDamge, transform.position + new Vector3(0, 0, -1), 
    //            hitDamge.transform.rotation);
    //        monster = other.gameObject.GetComponent<Monster>();
    //        count -= monster.damge;
    //        health.text = count.ToString();
    //    }
    //}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Monster1" || other.tag == "Monster2" || other.tag == "Monster3" ||
            other.tag == "Monster4" || other.tag == "Monster5")
        {
            Instantiate(hitDamge, transform.position + new Vector3(0, 0, -1),
                hitDamge.transform.rotation);
            monster = other.gameObject.GetComponent<Monster>();
            count -= monster.damge;
            health.text = count.ToString();
        }
    }
}
