using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CoinSpawnController csc;
    [SerializeField] ScoreController s;
    [SerializeField] GameController gc;
    [SerializeField] PanelController pc;

    bool canSpawn = false;

    void Start()
    {
        s.setCoins(100);
    }
    void Update()
    {
        if (gc.getIsLost()) return;

        if (!gc.getGameStarted())
        {
            if (Input.GetMouseButtonUp(0))
            {
                gc.setGameStarted(true);
                pc.gameStarted();
            }
        }

        if (!EventSystem.current.IsPointerOverGameObject() && EventSystem.current != null)
        {
            if (s.getCoins() > 0)
            {
                if (Input.GetMouseButtonDown(0))
                    canSpawn = true;

                if (Input.GetMouseButtonUp(0))
                {
                    csc.spawnCoin();
                    s.decreaseCoins(1);

                    if (s.getCoins() <= 0 && !gc.getIsLost())
                        gc.resetTimer();

                    canSpawn = false;
                }
            }
        }
    }
}
