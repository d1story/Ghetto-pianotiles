using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beats : MonoBehaviour
{
    public GameObject D, F, J, K;
    float []Nextnote = {};
    public float BPM, timeofnothingness, fallingTimeInBeats;
    int number, pos;
    float songpos, songposB, songstartpos, secperbeat;
    // Start is called before the first frame update
    void Start()
    {
        secperbeat = 60f / BPM;
        songstartpos = (float) AudioSettings.dspTime + timeofnothingness;
        GetComponent<AudioSource>().Play();
    }

    public float getnoteB()
    {
        if (number < Nextnote.Length)
            return Nextnote[number];
        return -1;
    }

    public float getsongposB()
    {
        return songposB;
    }
    // Update is called once per frame
    void Update()
    {
        songpos = (float)AudioSettings.dspTime - songstartpos;
        songposB = songpos / secperbeat;
        if(number<Nextnote.Length&& Nextnote[number]< songposB + fallingTimeInBeats)
        {
            pos = Random.Range(0, 3);
            Vector2 spawn;
            switch (pos){
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
    }
}
