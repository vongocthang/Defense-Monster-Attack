using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        int so = PlayerPrefs.GetInt("SceneOpened");
        Debug.Log(so);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
