using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int bestScore;
    public string bestPlayer;
    //public TMP_InputField playerName;
    public string activePlayer;
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
                
    }

    [System.Serializable]
    
    class SaveElements
    {
        public int bestScore;
        public string bestPlayer;
        public string player;
    }

    public void SaveData()
    {
        SaveElements elements = new SaveElements();
        elements.bestPlayer = bestPlayer;
        elements.bestScore = bestScore;
        

        string json = JsonUtility.ToJson(elements);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveElements elements = JsonUtility.FromJson<SaveElements>(json);

            bestPlayer = elements.bestPlayer;
            bestScore = elements.bestScore;
        }
    }
    public void ActiveGame(string player)
    {
        activePlayer = player;
    }
}
