using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerStatus : MonoBehaviour
{
    public GameObject[] serv;
    public GameObject[] showDetObj;
    Animator[] animator = new Animator[12];
    Animator[] animCloud = new Animator[12];
    TriggerCheck[] chekingTriggers = new TriggerCheck[12];

    bool[] ifBreaking = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };
    bool[] ifBroken = new bool[12] { false, false, false, false, false, false, false, false, false, false, false, false };

    public int[] whichDetailNeed = new int[12] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    public float[] timerToFix = new float[12] { 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20 };
    public float timerToRecover = 5;
    int curServer = 0;
    int curDetail = 0;
    bool ifAllBreaking = false;

    //public AudioSource DeathSound;
    //public AudioSource FixSound;

    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            animator[i] = serv[i].GetComponent<Animator>();
            animCloud[i] = showDetObj[i].GetComponent<Animator>();
        }
        chekingTriggers[0] = GameObject.FindGameObjectWithTag("Server0").GetComponent<TriggerCheck>();
        chekingTriggers[1] = GameObject.FindGameObjectWithTag("Server1").GetComponent<TriggerCheck>();
        chekingTriggers[2] = GameObject.FindGameObjectWithTag("Server2").GetComponent<TriggerCheck>();
        chekingTriggers[3] = GameObject.FindGameObjectWithTag("Server3").GetComponent<TriggerCheck>();
        chekingTriggers[4] = GameObject.FindGameObjectWithTag("Server4").GetComponent<TriggerCheck>();
        chekingTriggers[5] = GameObject.FindGameObjectWithTag("Server5").GetComponent<TriggerCheck>();
        chekingTriggers[6] = GameObject.FindGameObjectWithTag("Server6").GetComponent<TriggerCheck>();
        chekingTriggers[7] = GameObject.FindGameObjectWithTag("Server7").GetComponent<TriggerCheck>();
        chekingTriggers[8] = GameObject.FindGameObjectWithTag("Server8").GetComponent<TriggerCheck>();
        chekingTriggers[9] = GameObject.FindGameObjectWithTag("Server9").GetComponent<TriggerCheck>();
        chekingTriggers[10] = GameObject.FindGameObjectWithTag("Server10").GetComponent<TriggerCheck>();
        chekingTriggers[11] = GameObject.FindGameObjectWithTag("Server11").GetComponent<TriggerCheck>();
    }
    void ChooseServersForBreaking(int count)
    {
        for (int i = 0; i < count; i++)
        {
            curServer = Random.Range(0, 12);
            while (ifBreaking[curServer] || ifBroken[curServer])
            {
                curServer = Random.Range(0, 12);
            }
            ifBreaking[curServer] = true;
            animator[curServer].SetBool("IfBreakParam", true);

            curDetail = Random.Range(0, 3);
            whichDetailNeed[curServer] = curDetail;
            animCloud[curServer].SetInteger("WhichDetail", curDetail);
            timerToFix[curServer] -= Time.deltaTime;
        }
    }

    void CheckIfAllBreaking()
    {
        int breakingCount = 0;
        for(int i = 0; i < 12; i++)
        {
            if (ifBreaking[i])
            {
                breakingCount++;
            }
        }
        if(breakingCount == 12)
        {
            ifAllBreaking = true;
        }
        else
        {
            ifAllBreaking = false;
        }
    }

    int CheckFreeServersCount()
    {
        int counter = 0;
        for(int i = 0; i < 12; i++)
        {
            if (!ifBreaking[i])
            {
                counter++;
            }
        }
        return counter;
    }

    private void Update()
    {
        if(timerToRecover == 5)
        {
            CheckIfAllBreaking();
            if (!ifAllBreaking)
            {
                if(CheckFreeServersCount() >= 3)
                {
                    ChooseServersForBreaking(3);
                }
                else
                {
                    ChooseServersForBreaking(CheckFreeServersCount());
                }
            }
        }
        timerToRecover -= Time.deltaTime;
        if(timerToRecover <= 0)
        {
            timerToRecover = 5;
        }
        for(int i = 0; i < 12; i++)
        {
            if (ifBreaking[i] && timerToFix[i] <= 0)
            {
                //DeathSound.Play();
                ifBroken[i] = true;
                animCloud[i].SetInteger("WhichDetail", -1);
                whichDetailNeed[i] = -1;
                //death
            }
            if (chekingTriggers[i].IsNecessaryDetailExist && timerToFix[i] < 20 && timerToFix[i] > 0)
            {
                //FixSound.Play();
                chekingTriggers[i].IsNecessaryDetailExist = false;
                animator[i].SetBool("IfBreakParam", false);
                animCloud[i].SetInteger("WhichDetail", -1);
                ifBreaking[i] = false;
                whichDetailNeed[i] = -1;
                timerToFix[i] = 20;
            }
            if(timerToFix[i] < 20 && timerToFix[i] > 0)
            {
                timerToFix[i] -= Time.deltaTime;
            }

        }

    }
    public int AliveServers()
    {
        int counter = 0;
        for(int i = 0; i < 12; i++)
        {
            if (!ifBroken[i])
                counter++;
        }
        return counter;
    }
}
