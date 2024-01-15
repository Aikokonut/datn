using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    public Text[] itemTextFields;
    public GameObject[] itemPrefabs;
    private Dictionary<string, int> itemCounts;
    public Text scoreText;
    public Text highscoreText;
   
    private PlayerController playerController;
    public int score;
    public int highscore;
    public static FinalScore instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.PlayerDied += PlayerDiedHandler;
        itemCounts = new Dictionary<string, int>();
    }
    void Update()
    {
        if (playerController != null)
        {
            scoreText.text = score.ToString();
            highscoreText.text = highscore.ToString();
            Scored();
            HighScored();
        }
    }
    void PlayerDiedHandler()
    {
        Debug.Log("Player Died!");
        DisplayItemCount();
    }
    public void AddPoint()
    {
        score += 10;
        Debug.Log("+1");
    }
    public void Scored()
    {
        
            if (score <= PlayerPrefs.GetInt("Highscore", score))
            {
               
                scoreText.text = score.ToString();
            }
            //else
            //{
            //    CS.SetActive(false);
            //}
        
        //scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }
    public void HighScored()
    {
       
            if (score > PlayerPrefs.GetInt("Highscore", 0))
            {
                //HS.SetActive(true);
                PlayerPrefs.SetInt("Highscore", score);
                highscoreText.text = highscore.ToString();
            }
            //else
            //{
            //    HS.SetActive(false);
            //}
        
        //highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();

    }
    public void ItemReceived(string itemType)
    {
        if (!itemCounts.ContainsKey(itemType))
        {
            itemCounts[itemType] = 1;
        }
        else
        {
            itemCounts[itemType]++;
        }
        UpdateItemText(itemType);
    }
    private void DisplayItemCount()
    {
        for (int i = 0; i < itemTextFields.Length; i++)
        {
            string itemType = itemPrefabs[i].name;
            if (itemCounts.ContainsKey(itemType))
            {
                itemTextFields[i].text = $"{itemType}: {itemCounts[itemType]}";
            }
            else
            {
                itemTextFields[i].text = $"{itemType}: 0";
            }
        }
    }
    void UpdateItemText(string itemType)
    {
        for (int i = 0; i < itemTextFields.Length; i++)
        {
            if (itemTextFields[i].text.Contains(itemType))
            {
                itemTextFields[i].text = $"{itemType}: {itemCounts[itemType]}";
                break;
            }
        }
    }
}
