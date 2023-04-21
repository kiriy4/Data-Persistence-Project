using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
[DefaultExecutionOrder(1000)]
public class UIMenu : MonoBehaviour
{
    public TextMeshProUGUI bestPlayerText;
    public Button startButton;
    public Button exitButton;
    public TMP_InputField playerName;
    public GameObject warningText;
    private int bestScore;
    private string bestPlayer;

    // Start is called before the first frame update
    
    private void Start()
    {
        BestPlayer();
    }

    private void Update()
    {
        if (playerName.text != "")
        {
            startButton.gameObject.SetActive(true);
                        
        }else
        {
            startButton.gameObject.SetActive(false);
        }
        
    }

    public void BestPlayer()
    {
        bestPlayer = ScoreManager.Instance.bestPlayer;
        bestScore = ScoreManager.Instance.bestScore;
        bestPlayerText.text = "Best Player " + bestPlayer + ": " + bestScore;
    }

    public void StartGame()
    {

        Debug.Log("Game started. Player name is: " + playerName.text);
        SceneManager.LoadScene(1);
        ScoreManager.Instance.ActiveGame(playerName.text);
    }    


    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
