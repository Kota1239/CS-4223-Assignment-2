using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateLastGamesWord : MonoBehaviour
{
    public Text wordTextBox;
    public string TooltipText;

    void Start()
    {
        wordTextBox.text = TooltipText + GlobalSettings.GetLastGamesWord();
    } 
}
