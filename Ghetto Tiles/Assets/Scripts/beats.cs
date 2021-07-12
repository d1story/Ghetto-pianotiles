using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class beats : MonoBehaviour
{
    public GameObject D, F, J, K;
    float[] Nextnote = { 17.8f, 18.8f, 20.8f, 21.5f, 21.9f, 22.8f, 24.8f, 25.5f, 25.9f, 26.8f, 28.8f, 29.5f };
    public float BPM, timeofnothingness, fallingTimeInBeats;
    int number, pos;
    float songpos, songposB, songstartpos, secperbeat;

    private bool started = false;
    void Start()
    {

    }
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)//This + the upper two functions basically just triggers when the scene is loaded.
    {
        Debug.Log("Level Loaded");
        Debug.Log(scene.name);
        Debug.Log(mode);
        started = true;
        secperbeat = 60f / BPM;
        songstartpos = (float)AudioSettings.dspTime + timeofnothingness;
        GetComponent<AudioSource>().Play();
    }
    public float GetNoteB()
    {
        if (number < Nextnote.Length)
        {
            number++;
            return Nextnote[number - 1];
        }

        return -1;
    }
    public float GetSongPosB()
    {
        return songposB;
    }
    public float GetfallingTimeInBeats()
    {
        return fallingTimeInBeats;
    }
    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (number < Nextnote.Length && Nextnote[number] < songposB + fallingTimeInBeats)
            {
                pos = Random.Range(0, 3);
                Vector2 spawn;
                switch (pos)
                {
                    case 0:
                        spawn = new Vector2(-3, 6);
                        Instantiate(D, spawn, Quaternion.identity);
                        break;
                    case 1:
                        spawn = new Vector2(-1, 6);
                        Instantiate(F, spawn, Quaternion.identity);
                        break;
                    case 2:
                        spawn = new Vector2(1, 6);
                        Instantiate(J, spawn, Quaternion.identity);
                        break;
                    case 3:
                        spawn = new Vector2(3, 6);
                        Instantiate(K, spawn, Quaternion.identity);
                        break;
                }

            }
            songpos = (float)AudioSettings.dspTime - songstartpos;
            songposB = songpos / secperbeat;
        }
    }
}
