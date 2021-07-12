using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    private int points = 0;
    public Text pointsText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string pointsString = points.ToString();
        pointsText.text = (pointsString);
    }

    public void normalHit()//gain the points given from a normal hit... maybe add more precision in hits later?
    {
        points += 150;
    }

    public void wrongHit()
    {
        points -= 50;
    }
}
