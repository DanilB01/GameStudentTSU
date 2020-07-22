using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReadyToFinal : MonoBehaviour
{
    [SerializeField] bool startFinal = false;
    [SerializeField] public Text dialogBoxText;
    [SerializeField] public Text dialogBoxSpeakerName;
    [SerializeField] public Text buttonText;
    [SerializeField] public GameObject dialogBox;
    [SerializeField] public Button proceedButton;
    [SerializeField] public string speakerName = "";

    private int sIndex = 0;

    void Start()
    {
        CheckMarks();
        startFinal = true;
        if (startFinal)
        {
            string EndWords = "Всё готово для финального аккорда. Сдача закончена. Ты готов отправиться домой?";
            dialogBoxText.text = "";
            buttonText.text = "Finalize";
            dialogBoxSpeakerName.text = speakerName;
            dialogBox.SetActive(true);
            foreach (char t in EndWords)
            {
                dialogBoxText.text += t;
            }
            proceedButton.onClick.AddListener(StartFinal);
        }
    }

    void CheckMarks()
    {
        foreach (int mark in Marks.examMarks)
        {
            if (mark >= 1)
                startFinal = true;
            else
            {
                startFinal = false;
                break;
            }
        }
         foreach (int mark in Marks.passMarks)
         {
            if (mark != -1 && mark != 0 && mark != 2)
                startFinal = true;
            else
            {
                startFinal = false;
                break;
            }
         }

        
    }

    void StartFinal()
    {
      SceneManager.LoadScene("Final");
    }
}
