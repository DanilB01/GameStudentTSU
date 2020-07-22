using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksChanger : MonoBehaviour
{
    public GameObject[] examMarksAsset;
    public GameObject[] passMarksAsset;

    public GameObject[] passPlaces;
    public GameObject[] examPlaces;

    private void Start()
    {
        for (int i = 0; i < passPlaces.Length; i++)
        {
            if (Marks.passMarks[i] != -1)
            {
                Instantiate(passMarksAsset[Marks.passMarks[i]], passPlaces[i].transform);
            }
        }

        for (int i = 0; i < examPlaces.Length; i++)
        {
            if (Marks.examMarks[i] != 0)
            {
                Instantiate(examMarksAsset[Marks.examMarks[i] - 2], examPlaces[i].transform);
            }
        }
    }
}
