using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

// 1. JSON verilerini eşleştirmek için gereken sınıflar (Eksik olan kısım burasıydı)
[System.Serializable]
public class QuestionData
{
    public string questionText;
    public string[] options;
    public int correctAnswerIndex;
}

[System.Serializable]
public class QuestionList
{
    public QuestionData[] questions;
}

// 2. Ana oyun yöneticisi
public class QuizManager : MonoBehaviour
{
    [Header("UI Elemanları")]
    public TextMeshProUGUI questionTextUI;
    public Button[] optionButtons;
    public Button nextButton;

    [Header("Görsel Geri Bildirim Renkleri")]
    public Color normalColor = Color.white;
    public Color correctColor = Color.green;
    public Color wrongColor = Color.red;

    private QuestionList quizData;
    private int currentQuestionIndex = 0;

    void Start()
    {
        nextButton.onClick.AddListener(NextQuestion);
        nextButton.gameObject.SetActive(false); 

        LoadQuizData();
        DisplayQuestion(currentQuestionIndex);
    }

    void LoadQuizData()
    {
        // "Questions" isimli JSON dosyasının Resources klasöründe olduğundan emin ol
        TextAsset jsonFile = Resources.Load<TextAsset>("Questions"); 
        if (jsonFile != null)
        {
            quizData = JsonUtility.FromJson<QuestionList>(jsonFile.text);
        }
        else
        {
            Debug.LogError("Questions.json dosyası bulunamadı! Lütfen Assets/Resources klasörüne eklediğinden emin ol.");
        }
    }

    void DisplayQuestion(int index)
    {
        if (quizData != null && index < quizData.questions.Length)
        {
            QuestionData currentQuestion = quizData.questions[index];
            questionTextUI.text = currentQuestion.questionText;

            for (int i = 0; i < optionButtons.Length; i++)
            {
                optionButtons[i].GetComponent<Image>().color = normalColor;
                optionButtons[i].interactable = true;
                
                optionButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = currentQuestion.options[i];
                
                int answerIndex = i; 
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex, currentQuestion.correctAnswerIndex));
            }

            nextButton.gameObject.SetActive(false);
        }
        else
        {
            questionTextUI.text = "Test Tamamlandı!";
            foreach (Button btn in optionButtons)
            {
                btn.gameObject.SetActive(false);
            }
        }
    }

    void CheckAnswer(int chosenIndex, int correctIndex)
    {
        foreach (Button btn in optionButtons)
        {
            btn.interactable = false;
        }

        if (chosenIndex == correctIndex)
        {
            optionButtons[chosenIndex].GetComponent<Image>().color = correctColor;
        }
        else
        {
            optionButtons[chosenIndex].GetComponent<Image>().color = wrongColor;
            optionButtons[correctIndex].GetComponent<Image>().color = correctColor;
        }

        nextButton.gameObject.SetActive(true);
    }

    void NextQuestion()
    {
        currentQuestionIndex++;
        DisplayQuestion(currentQuestionIndex);
    }
}