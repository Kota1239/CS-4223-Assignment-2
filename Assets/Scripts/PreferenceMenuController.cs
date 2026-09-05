using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PreferenceMenuController : MonoBehaviour
{
    public TMP_Dropdown difficultySelector;
    public TMP_Dropdown lengthSelector;

    void Start()
    {
        difficultySelector.value = GlobalSettings.GetDifficulty();
        lengthSelector.value = GlobalSettings.GetWordLength();
    }

    public void SetDifficulty()
    {
        GlobalSettings.SetDifficulty(difficultySelector.value);
    }

    public void SetWordLength()
    {
        GlobalSettings.SetWordLength(lengthSelector.value);
    }
}
