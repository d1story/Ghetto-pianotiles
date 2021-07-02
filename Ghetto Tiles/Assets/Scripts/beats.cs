using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beats : MonoBehaviour
{
    float []Nextnote = {};
    public float BPM, timeofnothingness, beatfall;
    int number, prev;
    float songpos, songposB, songstartpos, secperbeat;
    // Start is called before the first frame update
    void Start()
    {
        prev = 1;
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
            prev += Random.Range(1, 3);
            prev %= 4;
            notes.Instantiate(prev, Nextnote[number], songposB);
            number++;
        }
    }
}
