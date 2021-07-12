using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{

    public float fallingTimeInBeats;//The time it takes for the beat to reach the hitbar in beats.
    public float noteBeat;//The beat of this note
    public float songPosInBeats;
    private Beats beatController;
    Vector2 SpawnPos;
    Vector2 RemovePos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        fallingTimeInBeats = 8f;
        RemovePos = SpawnPos;
        RemovePos.y = SpawnPos.y - 12f;

        GameObject beatControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (beatControllerObject != null)
        {
            beatController = beatControllerObject.GetComponent<Beats>();
        }

        //get the noteBeat
        noteBeat = beatController.GetNoteB();
    }

    public void DestroyNote()
    {
        //get reference to class which contains points in start.
        Destroy(gameObject);
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
