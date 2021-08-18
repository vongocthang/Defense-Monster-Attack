using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SceneOpened", 0);
        PlayerPrefs.SetInt("SoundBackground", 1);
        PlayerPrefs.SetInt("SoundEffect", 1);
    }
}
