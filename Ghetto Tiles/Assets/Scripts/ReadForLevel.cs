using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ReadForLevel : MonoBehaviour
{
    public TextAsset PathBeat, PathStretch;
    public List<BeatStructure> GetInfo()
    {
        List<BeatStructure> ret = new List<BeatStructure>();
        //importing the text as strings
        string textBeat, textStretch;
        textBeat = PathBeat.text;
        textStretch = PathStretch.text;
        string[] beatbit = textBeat.Split(' ');
        string[] stretchbit = textStretch.Split(' ');
        BeatStructure PlaceHold = new BeatStructure();
        for(int i=0;i< beatbit.Length&& i < beatbit.Length; i++)
        {
            PlaceHold.beat = float.Parse(beatbit[i]);
            PlaceHold.stretch = float.Parse(stretchbit[i]);
            ret.Add(PlaceHold);
        }
        return ret;
    }
}
