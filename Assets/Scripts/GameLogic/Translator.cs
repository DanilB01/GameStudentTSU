using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Translator : MonoBehaviour
{
    // Start is called before the first frame update
    public static int fromLevel = 8;
    [SerializeField] Transform[] ReturnPoints = new Transform[9];
    [SerializeField] GameObject Hero;
    public static int floorNum = 0;
    [SerializeField] GameObject floor0;
    [SerializeField] GameObject floor1;
    [SerializeField] GameObject MainCamera;

    void Start()
    {
        AfterLevelsCheck();
        var SpawnPoint = new Vector3(0, 0, 8);
        SpawnPoint.x = ReturnPoints[fromLevel].position.x;
        SpawnPoint.y = ReturnPoints[fromLevel].position.y;
        MainCamera.transform.position = SpawnPoint;
        Hero.transform.position = SpawnPoint;
        fromLevel = 8;//startPoint
    }
    public void AfterLevelsCheck()
    {
        if (Translator.fromLevel == 7)
        {
            floor0.SetActive(true);
            floor1.SetActive(false);
        }
    }

}
