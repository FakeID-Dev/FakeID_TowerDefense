using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("MusicPlaying") == 0)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
