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
        SpawnPos = transform.position;
        fallingTimeInBeats = 2f;
        RemovePos.y = SpawnPos.y - 10f;
        //get the noteBeat
    }

    void Update()
    {
        //get the songposintbeat
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
    }
}
