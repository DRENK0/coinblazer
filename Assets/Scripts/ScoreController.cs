using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour
{
    int Score = 0;
    [SerializeField] TextMeshProUGUI ScoreText;

    int CoinsCount = 0;
    [SerializeField] TextMeshProUGUI CoinsCountText;

    float Luck = 1;
    [SerializeField] TextMeshProUGUI LuckText;

    float LuckTimer = 0;
    [SerializeField] TextMeshProUGUI LuckTimerText;

    //End
    [SerializeField] TextMeshProUGUI BestScoreText;
    [SerializeField] TextMeshProUGUI FinalScoreText;

    void Update()
    {
        if(Luck == 1.5f)
        {
            if(LuckTimer > 0.0f)
            {
                LuckTimer -= Time.deltaTime;
                updateLuckTimer();
            }
            else
            {
                setLuck(1.0f);
                setLuckTimer(0);
                updateLuckTimer();
                updateLuck();
            }
        }
    }

    //At End Of Game
    public void ShowEnd()
    {
        FinalScoreText.text = "Score: " + Score.ToString();

        if (!PlayerPrefs.HasKey("Best"))
        {
            PlayerPrefs.SetInt("Best", Score);
            BestScoreText.text = "Best: " + Score.ToString();
        }
        else
        {
            if(PlayerPrefs.GetInt("Best") < Score)
            {
                PlayerPrefs.SetInt("Best", Score);
                FinalScoreText.text = "Score: " + Score.ToString();
                BestScoreText.text = "Best: " + Score.ToString();
            }
            else
            {
                FinalScoreText.text = "Score: " + Score.ToString();
                BestScoreText.text = "Best: " + PlayerPrefs.GetInt("Best").ToString();
            }
        }
    }

    //Coins
    public void increaseCoins(int amount) { CoinsCount += amount; updateCoins(); }
    public void decreaseCoins(int amount) { CoinsCount -= amount; updateCoins(); }
    public void setCoins(int amount) { CoinsCount = amount; updateCoins(); }
    public int getCoins() { return CoinsCount; }
    public void updateCoins() { CoinsCountText.text = CoinsCount.ToString(); }

    //Score
    public void addScore(int amount) { Score += amount; updateScore(); }
    public void removeScore(int amount) { Score -= amount; updateScore(); }
    public void setScore(int amount) {  Score = amount; updateScore(); }
    public int getScore() { return Score; }
    public void updateScore() {  ScoreText.text = Score.ToString(); }

    //Luck
    public void setLuck(float amount) { Luck = amount; updateLuck(); }
    public float getLuck() {  return Luck; }
    public void updateLuck() { if (SceneManager.GetActiveScene().name == "WebGL") { LuckText.text = " " + Luck.ToString() + "x"; } else { LuckText.text = Luck.ToString() + "x"; } }

    public void setLuckTimer(float amount) { LuckTimer = amount; updateLuckTimer(); } 
    public float getLuckTimer() {  return LuckTimer; }
    public void updateLuckTimer() { if (LuckTimer <= 0.0f) LuckTimerText.text = ""; else LuckTimerText.text = LuckTimer.ToString("00") + "s"; }
}
