using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    private int points;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void normalHit()//gain the points given from a normal hit... maybe add more precision in hits later?
    {
        points += 100;
        Debug.Log(points);
    }
}
