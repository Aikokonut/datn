using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance; 

    [SerializeField] private GameObject gameComplete;
    [SerializeField] private QuizData questionDataScriptable;
    [SerializeField] private Image questionImage;          
    [SerializeField] private WordData[] answerWordList;     
    [SerializeField] private WordData[] optionsWordList;
    [SerializeField] private Text wrongAnswerText;
    [SerializeField] private Button nextButton;

    public Text level;
    int x = 1;
    private GameStatus gameStatus = GameStatus.Playing;     
    private char[] wordsArray = new char[13];              

    private List<int> selectedWordsIndex;                 
    private int currentAnswerIndex = 0, currentQuestionIndex = 0;  
    private bool correctAnswer = true;                   
    private string answerWord;
    private List<AudioSource> audioSources;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        audioSources = new List<AudioSource>();
        for (int i = 0; i < questionDataScriptable.questions.Count; i++)
        {
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSources.Add(audioSource);
        }
    }

    void Start()
    {
        selectedWordsIndex = new List<int>();   
        
        SetQuestion();
        wrongAnswerText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
        nextButton.onClick.AddListener(NextQuestion);
    }

    void SetQuestion()
    {
        gameStatus = GameStatus.Playing;                
        answerWord = questionDataScriptable.questions[currentQuestionIndex].answer;
        questionImage.sprite = questionDataScriptable.questions[currentQuestionIndex].questionImage;

        ResetQuestion();                                 

        selectedWordsIndex.Clear();                     
        Array.Clear(wordsArray, 0, wordsArray.Length);  
        for (int i = 0; i < answerWord.Length; i++)
        {
            wordsArray[i] = char.ToUpper(answerWord[i]);
        }
        for (int j = answerWord.Length; j < wordsArray.Length; j++)
        {
            wordsArray[j] = (char)UnityEngine.Random.Range(65, 90);
        }

        wordsArray = ShuffeList.ShuffleListItems<char>(wordsArray.ToList()).ToArray(); 
        for (int k = 0; k < optionsWordList.Length; k++)
        {
            optionsWordList[k].SetWord(wordsArray[k]);
        }
        bool allAnswersFilled = selectedWordsIndex.Count == answerWord.Length;
        bool correctAnswers = true;
        if (allAnswersFilled)
        {
            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordList[i].wordValue))
                {
                    correctAnswers = false;
                    break;
                }
            }
        }

        if (allAnswersFilled && !correctAnswers)
        {
            wrongAnswerText.gameObject.SetActive(true);
            Debug.Log("Sai");
            nextButton.gameObject.SetActive(true);
            return;
        } 
        wrongAnswerText.gameObject.SetActive(false);
        nextButton.gameObject.SetActive(false);
    }
    public void NextQuestion() => SetQuestion();
    public void ResetQuestion()
    {
        for (int i = 0; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(true);
            answerWordList[i].SetWord(' ');
        }
        for (int i = answerWord.Length; i < answerWordList.Length; i++)
        {
            answerWordList[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < optionsWordList.Length; i++)
        {
            optionsWordList[i].gameObject.SetActive(true);
        }

        currentAnswerIndex = 0;
    }

    public void SelectedOption(WordData value)
    {
        if (gameStatus == GameStatus.Next || currentAnswerIndex >= answerWord.Length) return;

        selectedWordsIndex.Add(value.transform.GetSiblingIndex()); 
        value.gameObject.SetActive(false); 
        answerWordList[currentAnswerIndex].SetWord(value.wordValue); 

        currentAnswerIndex++;   
        if (currentAnswerIndex == answerWord.Length)
        {
            correctAnswer = true; 
            for (int i = 0; i < answerWord.Length; i++)
            {
                if (char.ToUpper(answerWord[i]) != char.ToUpper(answerWordList[i].wordValue))
                {
                    correctAnswer = false; 
                    break; 
                }
            }
            if (correctAnswer)
            {
                Debug.Log("Correct Answer");
                x += 1;
                level.text = x.ToString()+"/20";
                gameStatus = GameStatus.Next; 
                currentQuestionIndex++; 

                if (currentQuestionIndex < questionDataScriptable.questions.Count)
                {
                    Invoke("SetQuestion", 0.5f); 
                }
                else
                {
                    Debug.Log("Game Complete"); 
                    gameComplete.SetActive(true);
                }
            }
        }
    }
    public void ReturnWord()
    {
        if (selectedWordsIndex.Count > 0)
        {
            int index = selectedWordsIndex[selectedWordsIndex.Count - 1];
            optionsWordList[index].gameObject.SetActive(true);
            selectedWordsIndex.RemoveAt(selectedWordsIndex.Count - 1);
            currentAnswerIndex--;
        }
    }
}

[System.Serializable]
public class QuestionData
{
    public Sprite questionImage;
    public string answer;
    public AudioClip audioClip;
}

public enum GameStatus
{
    Next,
    Playing
}