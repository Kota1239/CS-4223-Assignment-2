using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using Microsoft.VisualBasic;


public class GameController : MonoBehaviour
{
    public TMP_Text timerText;
    public string timerTooltip = "Time Remaining: ";

    float timeLimit = 30f;
    float timeLeft = 30f;
    int wordLength = 5;

    // Dictionary of potential words
    [SerializeField] string[] ThreeLetterWords;
    [SerializeField] string[] FourLetterWords;
    [SerializeField] string[] FiveLetterWords;
    [SerializeField] string[] SixLetterWords;
    [SerializeField] string[] SevenLetterWords;

    // Letter containers
    public GameObject LetterOne;
    public GameObject LetterTwo;
    public GameObject LetterThree;
    public GameObject LetterFour;
    public GameObject LetterFive;
    public GameObject LetterSix;
    public GameObject LetterSeven;

    // Letter text
    public TMP_Text LetterOneText;
    public TMP_Text LetterTwoText;
    public TMP_Text LetterThreeText;
    public TMP_Text LetterFourText;
    public TMP_Text LetterFiveText;
    public TMP_Text LetterSixText;
    public TMP_Text LetterSevenText;

    public Scenes SceneManager;

    string TargetWord;
    char[] TargetCharacters;

    void Start()
    {
        FetchDifficulty();  // Get the user's selected difficulty and set the timer
        FetchWordLength();  // Get the user's selected word length
        CreateWord();       // Create a random word to guess
        UnityEngine.Debug.Log("Target word: " + TargetWord); // DEBUG - Sends target word to debug console
        PrepareLetters();   // Sets the proper amount of letters active depending on the word length
    }

    void Update()
    {
        TickTimer();        // Countdown the timer
        if (timeLeft <= 0f) // Loose the game if you run out of time
        {
            GlobalSettings.SetLastGamesWord(TargetWord);
            SceneManager.LooseGame();
        }
        CheckInput();       // Check user input against the secret word
        CheckWin();         // Check if user has won
    }

    void FetchDifficulty()  // Map selection value to a useable value
    {
        if(GlobalSettings.GetDifficulty() == 0)
        {
            timeLimit = 10f;
        }
        else if(GlobalSettings.GetDifficulty() == 1)
        {
            timeLimit = 20f;
        }
        else if(GlobalSettings.GetDifficulty() == 2)
        {
            timeLimit = 30f;
        }
        else if(GlobalSettings.GetDifficulty() == 3)
        {
            timeLimit = 60f;
        }
        else if(GlobalSettings.GetDifficulty() == 4)
        {
            timeLimit = 9999f;
        }
        else
        {
            timeLimit = 30f;
        }

        timeLeft = timeLimit;
    }

    void FetchWordLength()  // Map selection value to a useable value
    {
        if(GlobalSettings.GetWordLength() == 0)
        {
            wordLength = 7;
        }
        else if(GlobalSettings.GetWordLength() == 1)
        {
            wordLength = 6;
        }
        else if(GlobalSettings.GetWordLength() == 2)
        {
            wordLength = 5;
        }
        else if(GlobalSettings.GetWordLength() == 3)
        {
            wordLength = 4;
        }
        else if(GlobalSettings.GetWordLength() == 4)
        {
            wordLength = 3;
        }
        else
        {
            wordLength = 5;
        }
    }

    void TickTimer()        // Increment and update timer
    {
        timeLeft -= Time.deltaTime;
        timerText.text = timerTooltip + Mathf.RoundToInt(timeLeft) + "s";
    }

    void PrepareLetters()   // De-activates extra letter containers
    {
        if(wordLength == 3)
        {
            LetterFour.SetActive(false);
            LetterFive.SetActive(false);
            LetterSix.SetActive(false);
            LetterSeven.SetActive(false);
        }
        else if (wordLength == 4)
        {
            LetterFive.SetActive(false);
            LetterSix.SetActive(false);
            LetterSeven.SetActive(false);
        }
        else if (wordLength == 5)
        {
            LetterSix.SetActive(false);
            LetterSeven.SetActive(false);
        }
        else if (wordLength == 6)
        {
            LetterSeven.SetActive(false);
        }
    }

    string RandomizeWord()  // Picks a random word from the correct dictionary
    {
        int randomNumber;

        if(wordLength == 3)
        {
            randomNumber = Random.Range(0, ThreeLetterWords.Length);
            return ThreeLetterWords[randomNumber];
        }
        else if(wordLength == 4)
        {
            randomNumber = Random.Range(0, FourLetterWords.Length);
            return FourLetterWords[randomNumber];
        }
        else if(wordLength == 5)
        {
            randomNumber = Random.Range(0, FiveLetterWords.Length);
            return FiveLetterWords[randomNumber];
        }
        else if(wordLength == 6)
        {
            randomNumber = Random.Range(0, SixLetterWords.Length);
            return SixLetterWords[randomNumber];
        }
        else if(wordLength == 7)
        {
            randomNumber = Random.Range(0, SevenLetterWords.Length);
            return SevenLetterWords[randomNumber];
        }
        else return null;
    }

    void CreateWord()       // Creates the word variable and splits it into an array of characters
    {
        TargetWord = RandomizeWord();
        TargetWord = TargetWord.ToLower();
        TargetCharacters = TargetWord.ToCharArray();
    }

    void CheckInput()       // Checks the user's input for correct answers
    {
        char input;
        if(Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            input = Input.inputString.ToCharArray()[0];
            UnityEngine.Debug.Log(input);
            for (int i = 0; i < TargetCharacters.Length; i++)
            {
                if (input == TargetCharacters[i])
                {
                    UnityEngine.Debug.Log("You found letter " + TargetCharacters[i] + " in position " + i);
                    if (i == 0)
                    {
                        LetterOneText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 1)
                    {
                        LetterTwoText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 2)
                    {
                        LetterThreeText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 3)
                    {
                        LetterFourText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 4)
                    {
                        LetterFiveText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 5)
                    {
                        LetterSixText.text = TargetCharacters[i].ToString();
                    }
                    else if (i == 6)
                    {
                        LetterSevenText.text = TargetCharacters[i].ToString();
                    }
                    TargetCharacters[i] = '\0';
                }
            }
        }
    }

    void CheckWin()         // Checks if the player has won
    {
        int counter = 0;
        foreach (char letter in TargetCharacters)
        {
            if (letter == '\0') counter++;
        }
        GlobalSettings.SetLastGamesWord(TargetWord);
        if (counter == TargetCharacters.Length) SceneManager.WinGame();
    }
}