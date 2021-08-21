using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    float speed;
    Collider2D cd;
    Arrow arrow;

    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
        arrow = GetComponent<Arrow>();
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //
    void Move()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    //
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Monster1" || other.tag == "Monster2" || other.tag == "Monster3" ||
            other.tag == "Monster4" || other.tag == "Monster5")
        {
            cd.enabled = false;
            arrow.enabled = false;

            transform.SetParent(other.gameObject.transform);
        }

        if (other.tag == "Background")
        {
            Destroy(gameObject);
        }
    }
}
