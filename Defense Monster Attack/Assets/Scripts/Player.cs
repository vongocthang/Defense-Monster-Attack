using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float attackRate;
    float timeLine;
    public GameObject arrow;
    public GameObject imageArrow;
    Animator anim;
    Rigidbody2D arrowRb;
    float angle;
    AudioSource ado;

    // Start is called before the first frame update
    void Start()
    {
        attackRate = 0.2f;
        timeLine = Time.time;
        anim = GetComponent<Animator>();
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        arrowRb = arrow.GetComponent<Rigidbody2D>();
        ado = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Attack();

        //if (Time.time > timeLine + Random.Range(1, 2))
        //{
        //    Debug.Log(Time.time);
        //    timeLine = Time.time;
        //}
    }

    //
    void Attack()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    if(Time.time > timeLine + attackRate)
        //    {
        //        timeLine = Time.time;
        //        ado.Play();

        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        Vector3 a = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z);
        //        a = a - new Vector3(0, 0, ray.origin.z);
        //        Vector3 direction = a - arrow.transform.position;
        //        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //        arrowRb.rotation = angle;

        //        StartCoroutine(AnimDelay());
        //    }
        //}

        if (Input.touchCount > 0)
        {
            if (Time.time > timeLine + attackRate)
            {
                timeLine = Time.time;
                ado.Play();

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Vector3 a = new Vector3(ray.origin.x, ray.origin.y, ray.origin.z);
                a = a - new Vector3(0, 0, ray.origin.z);
                Vector3 direction = a - arrow.transform.position;
                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                arrowRb.rotation = angle;

                StartCoroutine(AnimDelay());
            }
        }
    }

    //Độ trễ của hoạt hình bắn cung
    IEnumerator AnimDelay()
    {
        anim.Play("Archer3_Attack1");

        yield return new WaitForSeconds(0.1f);

        GameObject clone = Instantiate(arrow, arrow.transform.position, arrow.transform.rotation);

        imageArrow= clone.transform.GetChild(0).gameObject;
        imageArrow.SetActive(true);
        clone.GetComponent<Arrow>().enabled = true;
        timeLine = Time.time;
    }
}
