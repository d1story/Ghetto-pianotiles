using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitNote : MonoBehaviour
{
    private Points p;
    bool right, d, f, j, k;
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
        notes notehere = collision.GetComponent<notes>();
        right = false;
        if (d&& notehere.transform.position.x == -3f)
        {
            right = true;
        }
        else if (f && notehere.transform.position.x == -1f)
        {
            right = true;
        }
        else if (j&&notehere.transform.position.x == 1f)
        {
            right = true;
        }
        else if (k && notehere.transform.position.x == 3f)
        {
            right = true;
        }
        if (right)
        {
            p.normalHit();
            notehere.DestroyNote();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) d = true;
        if (Input.GetKeyUp(KeyCode.D)) d = false;
        if (Input.GetKeyDown(KeyCode.F)) f = true;
        if (Input.GetKeyUp(KeyCode.F)) f = false;
        if (Input.GetKeyDown(KeyCode.J)) j = true;
        if (Input.GetKeyUp(KeyCode.J)) j = false;
        if (Input.GetKeyDown(KeyCode.K)) k = true;
        if (Input.GetKeyUp(KeyCode.K)) k = false;
    }
}
