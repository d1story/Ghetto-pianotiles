using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitNote : MonoBehaviour
{
    private Points p;
    bool right = false;
    private notes notehere;
    // Start is called before the first frame update
    void Start()
    {
        GameObject pointManagerObject = GameObject.FindGameObjectWithTag("PointManager");
        if (pointManagerObject != null)
        {
            p = pointManagerObject.GetComponent<Points>();
        }
    }
    // If the note touches da bar
    private void OnTriggerStay2D(Collider2D collision)
    {
        notehere = collision.GetComponent<notes>();

    }
    // Update is called once per frame
    void Update()
    {
        if (notehere != null)
        {
            if (Input.GetKeyDown(KeyCode.D) && notehere.transform.position.x == -3)
            {
                Debug.Log("D hit");
                right = true;
            }
            else if (Input.GetKeyDown(KeyCode.F) && notehere.transform.position.x == -1)
            {
                Debug.Log("F hit");
                right = true;
            }
            else if (Input.GetKeyDown(KeyCode.J) && notehere.transform.position.x == 1)
            {
                Debug.Log("J hit");
                right = true;
            }
            else if (Input.GetKeyDown(KeyCode.K) && notehere.transform.position.x == 3)
            {
                Debug.Log("K hit");
                right = true;
            }
            if (right)
            {
                p.normalHit();
                notehere.DestroyNote();
                right = false;
            }
        }

    }
}
