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
    beats beatController;
    // Start is called before the first frame update
    void Start()
    {
        beatController = GameObject.FindWithTag("b");
        SpawnPos = transform.position;
        fallingTimeInBeats = 2f;
        RemovePos = SpawnPos;
        RemovePos.y = SpawnPos.y - 10f;
        //get the noteBeat
        noteBeat = beatController.GetNoteB();
    }

    void Update()
    {
        //get the songposintbeat
        songPosInBeats = beatController.GetSongPosB();
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
    }
}
