using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Points : MonoBehaviour
{

    private float points = 0;
    public Text pointsText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string pointsString = Math.Floor(points).ToString();
        pointsText.text = (pointsString);
    }
    public void heldhit(float time)
    {
        //5 points per beat
        points += time * 5;
        Debug.Log(points);
    }
    public void normalHit()//gain the points given from a normal hit... maybe add more precision in hits later?
    {
        points += 150;
        Debug.Log(points);
    }

    public void wrongHit()
    {
        points -= 50;
        Debug.Log(points);
    }
}
