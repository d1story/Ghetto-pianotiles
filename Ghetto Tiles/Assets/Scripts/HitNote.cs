using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitNote : MonoBehaviour
{
    private Points p;
    bool d, f, j, k, isd, isf, isj, isk, hold, notecoming;
    float holdbegin, secperbeat;
    // Start is called before the first frame update
    void Start()
    {
        GameObject pointManagerObject = GameObject.FindGameObjectWithTag("PointManager");
        GameObject x = GameObject.FindGameObjectWithTag("GameController");
        if (x != null)
        {
            secperbeat = x.GetComponent<beats>().GetSecPerBeat();
        }
        if (pointManagerObject != null)
        {
            p = pointManagerObject.GetComponent<Points>();
        }
    }
    void turn_false(float a)
    {
        if (a == -3f) isd = false;
        else if (a == -1f) isf = false;
        else if (a == 1f) isj = false;
        else if (a == 3f) isk = false;
    }
    void turn_true(float a)
    {
        if (a == -3f) isd = true;
        else if (a == -1f) isf = true;
        else if (a == 1f) isj = true;
        else if (a == 3f) isk = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        notes notehere = collision.GetComponent<notes>();
        turn_false(notehere.transform.position.x);
        if (hold) { hold = false; p.GiveBack(); }
    }
    void normalnote(notes notehere)
    {
        bool right = false;
        if (d && isd)
        {
            right = true; d = false;
        }
        else if (f && isf)
        {
            right = true; f = false;
        }
        else if (j && isj)
        {
            right = true; j = false;
        }
        else if (k && isk)
        {
            right = true; k = false;
        }
        if (right)
        {
            p.normalHit();
            notehere.DestroyNote();
            turn_false(notehere.transform.position.x);
        }
    }
    // If the note touches da bar
    private void OnTriggerStay2D(Collider2D collision)
    {
        notes notehere = collision.GetComponent<notes>();
        turn_true(notehere.transform.position.x);
        if (notehere.Getstretch() > 0)
        {
            hold = true;
            notehere.holdEffects();

        }
        else normalnote(notehere);
    }
    // Update is called once per frame
    void Update()
    {
        notecoming = (isf || isd || isj || isk);
        //ugly, ugly but I don't want it to be too long
        if (notecoming)
        {
            if (Input.GetKeyDown(KeyCode.D)) d = true;
            if (Input.GetKeyUp(KeyCode.D)) { d = false; holdbegin = -1f; }
            if (Input.GetKeyDown(KeyCode.F)) f = true;
            if (Input.GetKeyUp(KeyCode.F)) { f = false; holdbegin = -1f; }
            if (Input.GetKeyDown(KeyCode.J)) j = true;
            if (Input.GetKeyUp(KeyCode.J)) { j = false; holdbegin = -1f; }
            if (Input.GetKeyDown(KeyCode.K)) k = true;
            if (Input.GetKeyUp(KeyCode.K)) { k = false; holdbegin = -1f; }
        }
        if (hold)
        {
            if (k && isk)
            {
                float T = Time.deltaTime;
                if (holdbegin > 0)
                    p.heldhit();
                holdbegin = T;
            }
            if (j && isj)
            {
                float T = Time.deltaTime;
                if (holdbegin > 0)
                    p.heldhit();
                holdbegin = T;
            }
            if (f && isf)
            {
                float T = Time.deltaTime;
                if (holdbegin > 0)
                    p.heldhit();
                holdbegin = T;
            }
            if (d && isd)
            {
                float T = Time.deltaTime;
                if (holdbegin > 0)
                    p.heldhit();
                holdbegin = T;
            }
        }
        if (!isd && d)
        {
            d = false;
            p.wrongHit();
        }
        if (!isf && f)
        {
            f = false;
            p.wrongHit();
        }
        if (!isj && j)
        {
            j = false;
            p.wrongHit();
        }
        if (!isk && k)
        {
            k = false;
            p.wrongHit();
        }
    }
}
