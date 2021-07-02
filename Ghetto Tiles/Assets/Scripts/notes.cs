using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{

    public float fallingTimeInBeats;//The time it takes for the beat to reach the hitbar in beats.
    private float noteBeat;//The beat of this note
    private float songPosInBeats;

    Vector2 SpawnPos;
    Vector2 RemovePos;

    // Start is called before the first frame update
    void Start()
    {
        fallingTimeInBeats = 2f;

    }

    void Instantiate(int identifier, float beatOfThisNote, float songPosBeats)//use this to determine whether the note is red, yellow, green or blue.
    {
        noteBeat = beatOfThisNote;
        songPosInBeats = songPosBeats;
        if (identifier == 0)
        {//red
            SpawnPos = new Vector2(-3, 6);
            RemovePos = new Vector2(-3, -4);
        }
        else if (identifier == 1)
        {//yellow
            SpawnPos = new Vector2(-1, 6);
            RemovePos = new Vector2(-1, -4);
        }
        else if (identifier == 2)
        {//green
            SpawnPos = new Vector2(1, 6);
            RemovePos = new Vector2(1, -4);
        }
        else if (identifier == 3)
        {//blue
            SpawnPos = new Vector2(3, 6);
            RemovePos = new Vector2(3, -4);
        }
    }

    void Update()
    {
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
    }
}
