using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogueText;

    public GameObject DialogBox;

    [Header("Dialogue Sentences")]
    [SerializeField] private string[] DialogSentences;
    int k = 0;
    public bool isCut = true;

    public void Start()
    {
            StartDialouge();
    }
    private void StartDialouge()
    {
      StartCoroutine(TypePlayerDialouge());
    }
    private IEnumerator TypePlayerDialouge()
    {
        foreach (string word in DialogSentences)
        {
            if (k == 3)
            {
                yield return new WaitForSeconds(5f);
                DialogueText.text = "";
                k = 0;
            }
            k++;
            foreach (char letter in word)
            {
                DialogueText.text += letter;
                yield return 0;
            }
        }
    }

}