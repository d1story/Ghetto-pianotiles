using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notes : MonoBehaviour
{
    float fallingTimeInBeats;//The time it takes for the beat to reach the hitbar in beats.
    float noteBeat;//The beat of this note
    float songPosInBeats;
    Vector3 stretch;
    private beats beatController;
    Vector2 SpawnPos;
    Vector2 RemovePos;
    BeatStructure Get;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        RemovePos = SpawnPos;
        RemovePos.y = SpawnPos.y - 100f;
        GameObject beatControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (beatControllerObject != null)
        {
            beatController = beatControllerObject.GetComponent<beats>();
            //get info from beats
            Get = beatController.GetNote();
            stretch.y = Get.stretch;
            noteBeat = Get.beat;
            fallingTimeInBeats = beatController.GetfallingTimeInBeats();
            gameObject.transform.localScale += stretch;
        }
        else Debug.Log("Missing object");
    }
    public float Getstretch()
    {
        return stretch.y;
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
        Debug.Log(noteBeat);
        Debug.Log(songPosInBeats);
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
        if (transform.position.y == RemovePos.y) { Destroy(gameObject); }
    }
}