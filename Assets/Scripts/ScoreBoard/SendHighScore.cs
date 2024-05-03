using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SendHighScore : MonoBehaviour
{
    [SerializeField] SendMail sm;
    [SerializeField] SpecialCoin coin;
    [SerializeField] GameController gc;

    [SerializeField] GameObject MainPanel;
    [SerializeField] GameObject NamePanel;
    [SerializeField] GameObject LeaderboardsPanel;

    [Space]

    [SerializeField] GameObject LeaderboardsButton;

    [SerializeField] TMP_InputField NameInput;

    [SerializeField] GameObject SpecialCoinText;

    public void sendScore()
    {
        if (NameInput.text.Length >= 3 && PlayerPrefs.GetInt("Best") > 0)
        {
            if (coin.getSpecialCoin())
                sm.SendEmail(NameInput.text);

            HighScores.UploadScore(NameInput.text, PlayerPrefs.GetInt("Best"));
            TriggerPanel(2);
        }
    }

    public void OnUpdateInputFieldName()
    {
        if (NameInput.text.Length >= 3)
            LeaderboardsButton.GetComponent<Button>().interactable = true;
        else
            LeaderboardsButton.GetComponent<Button>().interactable = false;
    }

    public void TriggerPanel(int index)
    {
        if (index == 0)
        {
            MainPanel.SetActive(true);
            NamePanel.SetActive(false);
            LeaderboardsPanel.SetActive(false);
        }
        else if (index == 1)
        {
            MainPanel.SetActive(false);
            NamePanel.SetActive(true);
            LeaderboardsPanel.SetActive(false);
        }
        else if (index == 2)
        {
            MainPanel.SetActive(false);
            NamePanel.SetActive(false);
            LeaderboardsPanel.SetActive(true);
        }
    }
    public void setSpecialCoin(bool state)
    {
        SpecialCoinText.SetActive(state);
    }
    public void setSpecialCoinText(string text)
    {
        SpecialCoinText.GetComponent<TextMeshProUGUI>().text = text;
    }
}
