using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    Collider2D cd;
    Arrow arrow;
    Transform monster;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        arrow = GetComponent<Arrow>();
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
