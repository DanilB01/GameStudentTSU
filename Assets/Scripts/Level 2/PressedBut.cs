using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedBut : MonoBehaviour
{
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public static bool isPressed;
    public static int whichPressed = -1;
    public int ButtonId;

    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        if(GenMemes.isPress < 20)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                theSR.sprite = pressedImage;
            }

            if (Input.GetKeyUp(keyToPress))
            {
                theSR.sprite = defaultImage;
                isPressed = true;
                whichPressed = ButtonId;
            }
        }
    }
}
