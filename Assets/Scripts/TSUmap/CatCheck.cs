using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCheck : MonoBehaviour
{
    public GameObject cat;
    void Start()
    {
        Time.timeScale = 1;//это для 3 уровня шоб работало
        if (Marks.examMarks[2] >= 3)
        {
            cat.SetActive(true);
        }
    }
}
