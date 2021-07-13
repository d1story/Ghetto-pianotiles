using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{

    float fallingTimeInBeats;//The time it takes for the beat to reach the hitbar in beats.
    float noteBeat;//The beat of this note
    float songPosInBeats;
    private beats beatController;
    private AudioSource HitSound;
    public GameObject effects;//particle effects
    Vector2 SpawnPos;
    Vector2 RemovePos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        fallingTimeInBeats = 2f;
        RemovePos = SpawnPos;
        RemovePos.y = SpawnPos.y - 12f;

        GameObject beatControllerObject = GameObject.FindGameObjectWithTag("GameController");//grab reference to beats script for values
        if (beatControllerObject != null)
        {
            beatController = beatControllerObject.GetComponent<beats>();
        }

        GameObject HitSoundObject = GameObject.FindGameObjectWithTag("HitSoundPlayer");//grab reference to play audio on note
        if (HitSoundObject != null)
        {
            HitSound = HitSoundObject.GetComponent<AudioSource>();
        }

        //get the noteBeat (what beat the note hits the line at)
        noteBeat = beatController.GetNoteB();
        //get the falling time in beats
        fallingTimeInBeats = beatController.GetfallingTimeInBeats();
    }

    public void DestroyNote()//make particles, play noise, then destroy object.
    {
        if (effects != null)
            Instantiate(effects, transform.position, Quaternion.identity);//create particle explosion
        else
        {
            Debug.Log("Prefab effects is not dragged into note prefabs.");
        }
        HitSound.Play();//play hit sound
        Destroy(gameObject);
    }
    void Update()
    {
        //get the songposinbeat
        songPosInBeats = beatController.GetSongPosB();

        transform.position = Vector2.Lerp(//linearly interpolate the position to move the notes.
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
        if (transform.position.y == RemovePos.y) Destroy(gameObject);//Destroy object once it's gone too far
    }
}