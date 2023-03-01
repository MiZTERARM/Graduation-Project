using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{
    public enum EButtonType
    {
        NotSet,
        PairNumberBtn,
        PuzzleCategoriesBtn,

    };
    [SerializeField] public EButtonType ButtonType = EButtonType.NotSet;
    [HideInInspector] public GameSettings.EPairNumber PairNumber = GameSettings.EPairNumber.NotSet;
    [HideInInspector] public GameSettings.EPuzzleCategories PuzzleCategories = GameSettings.EPuzzleCategories.NotSet;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SrtGameObtion(string GameSceneName)
    {
        var comp = gameObject.GetComponent<SetGameButton>();

        switch (comp.ButtonType)
        {
            case SetGameButton.EButtonType.PairNumberBtn:
                GameSettings.Instance.SetPairNumber(comp.PairNumber);
                break;
           case EButtonType.PuzzleCategoriesBtn:
               GameSettings.Instance.SetPuzzleCategories(comp.PuzzleCategories);
               break;
        }
        if (GameSettings.Instance.AllSettingsReady())
        {
            SceneManager.LoadScene(GameSceneName);
        }
    }
    


  
       
        


}
