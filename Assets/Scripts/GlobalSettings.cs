using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    public static string playerName = "Player";

    public static void SetPlayerName(string input)
    {
        playerName = input;
    }

    public static string GetPlayerName()
    {
        return playerName;
    }
}
