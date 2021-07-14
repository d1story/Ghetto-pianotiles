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
    private AudioSource HitSound;
    public GameObject effects;//particle effects
    // Start is called before the first frame update
    void Start()
    {
        SpawnPos = transform.position;
        RemovePos = SpawnPos;
        RemovePos.y = SpawnPos.y - 12f;
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

        GameObject HitSoundObject = GameObject.FindGameObjectWithTag("HitSoundPlayer");//grab reference to play audio on note
        if (HitSoundObject != null)
        {
            HitSound = HitSoundObject.GetComponent<AudioSource>();
        }
        else Debug.Log("Missing object");
    }
    public float Getstretch()
    {
        return stretch.y;
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

    public void holdEffects()
    {
        if (effects != null)
            Instantiate(effects, new Vector2(transform.position.x, -4), Quaternion.identity);//create particle explosion
        else
        {
            Debug.Log("Prefab effects is not dragged into note prefabs.");
        }
    }
    void Update()
    {
        songPosInBeats = beatController.GetSongPosB();
        transform.position = Vector2.Lerp(
            SpawnPos,
            RemovePos,
            (fallingTimeInBeats - (noteBeat - songPosInBeats)) / fallingTimeInBeats);
        if (transform.position.y == RemovePos.y) { Destroy(gameObject); }
    }
}
