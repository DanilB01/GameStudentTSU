using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialog : MonoBehaviour
{
    [SerializeField] public string [] sentences;
    [SerializeField] public Text dialogBoxText;
    [SerializeField] public Text dialogBoxSpeakerName;
    [SerializeField] public Text buttonText;
    [SerializeField] public GameObject dialogBox;
    [SerializeField] public Button proceedButton;
    [SerializeField] public string speakerName="";
    [SerializeField] private string FirstLevelSceneName = "TsuMap";

    private int sIndex = 0;

    void Start()
    {
        dialogBoxText.text = "";
    }

    void Update()
    {
        if (sIndex >= sentences.Length - 1)
        {
            buttonText.text = "Start Level";
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            dialogBoxText.text = "";
            dialogBoxSpeakerName.text = speakerName;
            dialogBox.SetActive(true);
            StartCoroutine(TypeNPCDialouge());
            proceedButton.onClick.AddListener(TaskOnClick);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            dialogBox.SetActive(false);
            sIndex = 0;
            dialogBoxText.text = "";
        }
    }

    void TaskOnClick()
    {
        if (sIndex < sentences.Length - 1)
        {
            dialogBoxText.text = "";
            sIndex++;
            StartCoroutine(TypeNPCDialouge());
        }
        else
        {
            //if(DataHolder.isFoodNeed[lvlnum - 1])
            //doing sth
            //else
            SceneManager.LoadScene(FirstLevelSceneName);
        }
    }

    private IEnumerator TypeNPCDialouge()
    {
        string sentence = sentences[sIndex];
        foreach (char letter in sentence)
        {
            dialogBoxText.text += letter;
            yield return 0; //new WaitForSeconds(0.2f);
        }
    }
}
