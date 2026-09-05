using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string playerNamePreference = "Player";

    // Difficulty and word length values are 0 through 4, with 0 being the hardest and 4 being the easiest.
    // For instance, 0 difficulty is expert (10 seconds) and 0 length is 7 letters.
    public static int difficultyPreference = 2;
    public static int wordLengthPreference = 2;

    public static string lastGamesWord;

    public static void SetPlayerName(string input)
    {
        playerNamePreference = input;
    }

    public static string GetPlayerName()
    {
        return playerNamePreference;
    }

    public static void SetDifficulty(int input)
    {
        difficultyPreference = input;
    }

    public static int GetDifficulty()
    {
        return difficultyPreference;
    }

    public static void SetWordLength(int input)
    {
        wordLengthPreference = input;
    }

    public static int GetWordLength()
    {
        return wordLengthPreference;
    }

    public static void SetLastGamesWord(string input)
    {
        lastGamesWord = input;
    }

    public static string GetLastGamesWord()
    {
        return lastGamesWord;
    }
}
