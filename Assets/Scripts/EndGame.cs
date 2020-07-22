using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("Opening Cutscene");
    }
}
