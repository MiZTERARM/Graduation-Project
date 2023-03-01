using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageManager : MonoBehaviour
{
    public List<ImgQuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionText;
    public Text ScoreText;

    int totalQuestions = 0;
    public int score;

    public AudioSource soundText;
    public AudioClip[] soundFile;

    private int soundNumber;

    public static int CorrectButton;

    public Button InteractableA;
    public Button InteractableB;
    public Button InteractableC;
    public Button InteractableD;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        soundText.PlayOneShot(soundFile[soundNumber]);
        QnA.RemoveAt(currentQuestion);
        InteractableA.interactable = false;
        InteractableB.interactable = false;
        InteractableC.interactable = false;
        InteractableD.interactable = false;
        StartCoroutine(SetTimeChangeQuestion());
    }

    public void wrong()
    {
        soundText.PlayOneShot(soundFile[soundNumber]);
        QnA.RemoveAt(currentQuestion);
        InteractableA.interactable = false;
        InteractableB.interactable = false;
        InteractableC.interactable = false;
        InteractableD.interactable = false;
        StartCoroutine(SetTimeChangeQuestion());
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<ImageAnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<ImageAnswerScript>().isCorrect = true;
                CorrectButton = i;
            }
        }
    }

    IEnumerator SetTimeChangeQuestion()
    {
        yield return new WaitForSeconds(GameSetting.Instance.Timer);
        InteractableA.interactable = true;
        InteractableB.interactable = true;
        InteractableC.interactable = true;
        InteractableD.interactable = true;
        generateQuestion();
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);
            QuestionText.text = QnA[currentQuestion].Question;
            soundNumber = QnA[currentQuestion].SoundUse;
            Debug.Log(soundNumber);
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }
    }
}
