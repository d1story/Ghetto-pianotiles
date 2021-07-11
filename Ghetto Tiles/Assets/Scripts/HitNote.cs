using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitNote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // If the note touches da bar
    private void OnTriggerStay(Collider other)
    {
        notes notehere = other.GetComponent<notes>();
        notehere.HitNote();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
