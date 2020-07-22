using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMemes : MonoBehaviour
{
    public GameObject[] Memes;
    public GameObject[] Buttons;
    private bool[] isUsed = new bool[10] { false, false, false, false, false, false, false, false, false, false };
    public int[] RightAnswer;
    public static int Score;
    private int numMem;
    private int answers;

    public GameObject FinalPanel;
    public float time;

    private int firstAnswer = -1;
    private int secondAnswer = -1;

    public static int isPress = 0;
    private int count = 1;

    // Start is called before the first frame update
    void Start()
    {
        isPress = 0;
        Score = 0;
        answers = 0;
        time = 10f;
        numMem = Random.Range(0, Memes.Length);
        Memes[numMem].SetActive(true);
        isUsed[numMem] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(answers == 2 || time < 0)
        {
            Score += ProccesingAnsvers();
            Memes[numMem].SetActive(false);
            while (isUsed[numMem] && count < 10)
            {
                numMem = Random.Range(0, Memes.Length);
            }
            count++;
            if(isPress == 20)
            {
                FinalPanel.SetActive(true);
                Time.timeScale = 0;
            }
            Memes[numMem].SetActive(true);
            isUsed[numMem] = true;
            time = 10f;
            answers = 0;
            PressedBut.isPressed = false;
            PressedBut.whichPressed = -1;
            firstAnswer = -1;
            firstAnswer = -1;
        }

        if (PressedBut.isPressed && isPress < 20)
        {
            isPress++;
            answers++;
            if(answers == 1)
            {
                firstAnswer = PressedBut.whichPressed;
            }
            if(answers == 2)
            {
                secondAnswer = PressedBut.whichPressed;
            }
            PressedBut.isPressed = false;
        }

        time -= Time.deltaTime;
    }

    int ProccesingAnsvers()
    {
        int point = 0;
        if(firstAnswer == RightAnswer[numMem] / 10 - 1)
        {
            point++;
            RightAnswer[numMem] %= 10;
        }
        if (firstAnswer == RightAnswer[numMem] % 10 - 1)
        {
            point++;
            RightAnswer[numMem] /= 10;
        }
        if (secondAnswer == RightAnswer[numMem] / 10 - 1)
        {
            point++;
            RightAnswer[numMem] %= 10;
        }
        if (secondAnswer == RightAnswer[numMem] % 10 - 1)
        {
            point++;
            RightAnswer[numMem] /= 10;
        }
        return point;
    }
}
