using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] public Text dialogBoxText;
    [SerializeField] public Text dialogBoxSpeakerName;
    [SerializeField] public Text buttonText;
    [SerializeField] public GameObject dialogBox;
    [SerializeField] public Button proceedButton;
    [SerializeField] public string speakerName="";
    [SerializeField] private string FirstLevelSceneName = "TsuMap";
    private string[] WorkSentences;
    public int lvlNum;
    public MainInventory MI;
    bool startSpeak = false;
    bool lastReplicEnded = true;

    private int sIndex = 0;
    private int Tindex = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Level1")
        {
            Tindex = 1;
            setRightSentences(Tindex);

        }
        if (collision.name == "Level2")
        {
            Tindex = 2;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level3")
        {
            Tindex = 3;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level4")
        {
            Tindex = 4;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level5")
        {
            Tindex = 5;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level6")
        {
            Tindex = 6;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level7")
        {
            Tindex = 7;
            setRightSentences(Tindex);
        }
        if (collision.name == "Level8")
        {
            Tindex = 8;
            setRightSentences(Tindex);
        }
        FirstLevelSceneName = DialogsBase.StartingScenes[Tindex - 1];
        speakerName = DialogsBase.TeacherNames[Tindex - 1];
    }

    void setRightSentences(int index)
    {
        if (DataHolder.isFoodNeed[index - 1])
            WorkSentences = DialogsBase.FoodTeacherList[index - 1];
        else
            WorkSentences = DialogsBase.MainTeacherList[index - 1];
    }

    void Start()
    { 
        proceedButton.onClick.AddListener(TaskOnClick);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Level1" || other.name == "Level2" || other.name == "Level3" || other.name == "Level4"|| other.name == "Level5" ||
            other.name == "Level6" || other.name == "Level7" || other.name == "Level8" || other.name == "Level")
        {
            if (!startSpeak)
            { 
                dialogBoxText.text = "";
                dialogBoxSpeakerName.text = speakerName;
                buttonText.text = "Поговорить";
                dialogBox.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Level1" || other.name == "Level2" || other.name == "Level3" || other.name == "Level4" || other.name == "Level5" ||
            other.name == "Level6" || other.name == "Level7" || other.name == "Level8" || other.name == "Level")
        {
            dialogBox.SetActive(false);
            dialogBoxText.text = "";
            startSpeak = false;
        }
    }

    void CheckFoodAvaible()
    {
        if (sIndex >= WorkSentences.Length - 1)//if(sIndex >= sentences.Length - 1)
        {
            //before change buttonText if на кол-во попыток и если >1 на наличие нужно еды {}
            if (!DataHolder.isFoodNeed[Tindex - 1])
                buttonText.text = "Приступить";
            else if (MI.isFoodExist(Tindex, "check"))
                buttonText.text = "Приступить";
            else
                buttonText.text = "Ясно";
        }
    }

    void TaskOnClick()
    {
        if (!startSpeak)
        {
            startSpeak = true;
            sIndex = 0;
        }
        else if (lastReplicEnded)
        {
            if (sIndex <= WorkSentences.Length - 1)
            {
                dialogBoxText.text = ""; 
                StartCoroutine(TypeNPCDialouge());
                sIndex++;
                buttonText.text = "Дальше";
            }
            else
            {
                CheckFoodAvaible();
                if (!DataHolder.isFoodNeed[Tindex - 1])
                    SceneManager.LoadScene(FirstLevelSceneName);
                else if (DataHolder.isFoodNeed[Tindex - 1] && MI.isFoodExist(Tindex, "remove"))
                    SceneManager.LoadScene(FirstLevelSceneName);
            }
        }
    }
    
    private IEnumerator TypeNPCDialouge()
    {
        lastReplicEnded = false;
        string sentence = WorkSentences[sIndex];
        foreach (char letter in sentence)
        {
            dialogBoxText.text += letter;
            yield return 0;
        }
        lastReplicEnded = true;
    }
}
