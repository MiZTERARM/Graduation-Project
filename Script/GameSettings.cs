using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
   private readonly Dictionary<EPuzzleCategories, string> _puzzleCatDirectory = new Dictionary<EPuzzleCategories, string>();
    private int _settings;
    private const int SrttingsNumber = 1;

    public enum EPairNumber
    {
        NotSet = 0,
        E20Pairs = 20,
        E30Pairs = 40,
        E52Pairs = 60,
    }
   public enum EPuzzleCategories
    {
        NotSet,
        Alphabet
    }
    public struct Settings
    {
        public EPairNumber PairsNumber;
        public EPuzzleCategories PuzzleCategory;
        
    };

    private Settings _gameSettings;

    public static GameSettings Instance;

    void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(target: this);
            Instance = this;
        }
        else
        {
            Destroy(obj: this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SetPuzzleCatDirectory();
        _gameSettings = new Settings();
        ResetGameSettings();
    }
    private void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EPuzzleCategories.Alphabet, "Puzzle");
       
    }
   public void SetPairNumber(EPairNumber Number)
    {
        if (_gameSettings.PairsNumber == EPairNumber.NotSet)
        {
            _settings++;

            
            _gameSettings.PairsNumber = Number;
        }
    }
    public void SetPuzzleCategories(EPuzzleCategories cat)
    {
        if (_gameSettings.PuzzleCategory == EPuzzleCategories.NotSet)
        {
            _settings++;


            _gameSettings.PuzzleCategory = cat;
        }
    }
    public EPairNumber GetPairNumber()
    {
        return _gameSettings.PairsNumber;
    }
   public EPuzzleCategories GetPuzzleCategories()
    {
        return _gameSettings.PuzzleCategory;
    }
    public void ResetGameSettings()
    {
        _settings = 0;
       _gameSettings.PuzzleCategory = EPuzzleCategories.NotSet;
        _gameSettings.PairsNumber = EPairNumber.NotSet;
        
    }
    public bool AllSettingsReady()
    {
        return _settings == SrttingsNumber;
    }
    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }
  public string GetPuzzleCategoryTextDirectoryName()
    {
        if (_puzzleCatDirectory.ContainsKey(_gameSettings.PuzzleCategory))
        {
            return "Resources/Puzzle" + _puzzleCatDirectory[_gameSettings.PuzzleCategory]+"/";
            
        }
        else
        {
            Debug.LogError("ERROR: CANNOT GET DIRECTORY NAME");
            return "";
        }
    }
}
