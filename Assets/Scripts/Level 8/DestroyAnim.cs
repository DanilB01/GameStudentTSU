using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    private Animator animator;
    public float timerToFix = 15;
    public float timerToRecover = 2;

    int breakingOrNot;
    bool ifBreaking = false;
    bool ifBroken = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!ifBroken)
        {
            if (!ifBreaking)
            {
                timerToRecover -= Time.deltaTime;
                if(timerToRecover <= 0)
                {
                    breakingOrNot = Random.Range(0, 2);
                    if (breakingOrNot == 1)
                    {
                        ifBreaking = true;
                        animator.SetBool("IfBreakParam", true);
                    }
                    timerToRecover = 2;
                }
            }
            else
            {
                timerToFix -= Time.deltaTime;
            }
            if(timerToFix <= 0)
            {
                ifBroken = false;
                timerToFix = 0;
            }
        }
        
        
    }
}
