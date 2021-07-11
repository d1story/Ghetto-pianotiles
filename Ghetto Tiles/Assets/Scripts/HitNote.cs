using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HitNote : MonoBehaviour
{
    private Points p;
    bool right;
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
        if (Input.GetKeyDown(KeyCode.D)&& notehere.transform.position.x == -3f)
        {
            right = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && notehere.transform.position.x == -1f)
        {
            right = true;
        }
        else if (Input.GetKeyDown(KeyCode.J)&&notehere.transform.position.x == 1f)
        {
            right = true;
        }
        else if (Input.GetKeyDown(KeyCode.K)&& notehere.transform.position.x == 3f)
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
        
    }
}
