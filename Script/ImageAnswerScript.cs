using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageAnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public ImageManager quizManager;

    public Color startColor;

    public Button[] CorrectAnswer;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Click);
            Debug.Log("Correct Answer");
            StartCoroutine(SetTimeChange(GameSetting.Instance.TimeChangeColor));
            Debug.Log("ComeBack");
            quizManager.correct();

        }
        else
        {
            GetComponent<Image>().color = Color.red;
            IncorrectSfxManager.sfxInstance.Audio.PlayOneShot(IncorrectSfxManager.sfxInstance.Click);
            Debug.Log("Wrong Answer");
            CorrectAnswer[ImageManager.CorrectButton].GetComponent<Image>().color = Color.green;
            StartCoroutine(SetTimeChange(GameSetting.Instance.TimeChangeColor));
            Debug.Log("ComeBack");
            quizManager.wrong();
        }
    }

    IEnumerator SetTimeChange(float i)
    {
        // yield return new WaitForSeconds(i);
        // soundText.Play();
        yield return new WaitForSeconds(GameSetting.Instance.Timer - GameSetting.Instance.TimeChangeColor);
        Debug.Log("GETIN");
        GetComponent<Image>().color = Color.white;
        CorrectAnswer[ImageManager.CorrectButton].GetComponent<Image>().color = Color.white;
    }
}
