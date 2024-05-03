using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] ScoreController sc;
    [SerializeField] PanelController pc;
    [SerializeField] SendHighScore hc;
    [SerializeField] SpecialCoin coin;

    float EndTimer = 0f;

    bool isLost = false;

    bool gameStarted = false;

    bool triggerOnce = true;

    void Start()
    {
        triggerOnce = true;
    }

    void Update()
    {
        if (!gameStarted) return;

        if(sc.getCoins() <= 0)
        {
            if (EndTimer > 4.0f)
            {
                if (triggerOnce)
                {
                    sc.ShowEnd();
                    setIsLost(true);
                    pc.OpenTint(1);

                    if (coin.getSpecialCoin())
                    {
                        hc.setSpecialCoin(true);
                        hc.setSpecialCoinText("You got the special coin.\r\nEnter name to join raffle!");
                    }
                    else
                    {
                        hc.setSpecialCoin(false);
                        hc.setSpecialCoinText("");
                    }
                    triggerOnce = !triggerOnce;
                }
            }
            else
                EndTimer += Time.deltaTime;
        }
    }
    public void playAgain() { SceneManager.LoadScene("WebGL"); }
    public void playAgainMobile() { SceneManager.LoadScene("Mobile"); }
    public void resetTimer() { EndTimer = 0f; }
    public bool getIsLost() { return isLost; }
    public void setIsLost(bool lost) { isLost = lost; }
    public bool getGameStarted() {  return gameStarted; }
    public void setGameStarted(bool state) {  gameStarted = state; }
}
