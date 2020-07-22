using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGen : MonoBehaviour
{

    public bool hasStarted;

    public GameObject theArrow;
    public Transform generationPoint;
    
    public GameObject[] theArrows;
    private int arrowSelector;


    public GameObject[] Buttons;
    private int arrowButton;

    private float timer;
    private float scoreTime;

    public float minScoreTime;
    public float maxScoreTime;

    public static int totalNotes;

    private bool[] isUsed = new bool[4] { false, false, false, false };
    private int countGen;

    private int numStage;

    void Start()
    {
        timer = Random.Range(minScoreTime, maxScoreTime);
        scoreTime = 20;
        totalNotes = 0;
        numStage = 2;
        BeatScroller.beat = 280f / 60f;
    }

    void Update()
    {
        if (hasStarted)
        {
            if (timer < 0)
            {
                countGen = Random.Range(1, 4);
                for(int i = 0; i < countGen; i++)
                {
                    arrowSelector = Random.Range(0, theArrows.Length);

                    while (isUsed[arrowSelector])
                    {
                        arrowSelector = Random.Range(0, theArrows.Length);
                    }

                    isUsed[arrowSelector] = true;

                    transform.position = new Vector3(Buttons[arrowSelector].transform.position.x, generationPoint.position.y, transform.position.z);

                    Instantiate(theArrows[arrowSelector], transform.position, transform.rotation);
                    totalNotes++;
                }
                for (int i = 0; i < 4; i++)
                {
                    isUsed[i] = false;
                }

                timer = Random.Range(minScoreTime, maxScoreTime);
            }
            else
            {
                timer -= Time.deltaTime;
            }

            if (scoreTime < 0)
            {
                if(numStage == 2)
                {
                    minScoreTime = 0.7f;
                    maxScoreTime = 1.2f;
                    numStage++;
                    BeatScroller.beat = 320f / 60f;
                }

                if (numStage == 3)
                {
                    minScoreTime = 0.5f;
                    maxScoreTime = 0.7f;
                    BeatScroller.beat = 360f / 60f;
                }
                   
                scoreTime = 20;
            }
            else if(numStage != 3)
            {
                scoreTime -= Time.deltaTime;
            }

        }
        
    }
    
}
