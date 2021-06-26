using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beats : MonoBehaviour
{
    float []Nextnote = {};
    public float BPM, timeofnothingness, beatfall;
    int number;
    float songpos, songposB, songstartpos, secperbeat, diff;
    // Start is called before the first frame update
    void Start()
    {
        secperbeat = 60f / BPM;
        songstartpos = (float) AudioSettings.dspTime + timeofnothingness;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        songpos = (float)AudioSettings.dspTime - songstartpos;
        songposB = songpos / secperbeat;
        if(number<Nextnote.Length&& Nextnote[number]< songposB + beatfall)
        {
            //Instantiate( );
            number++;
        }
    }
}
