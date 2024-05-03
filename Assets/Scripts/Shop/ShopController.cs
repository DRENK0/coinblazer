using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class ShopController : MonoBehaviour
{
    [SerializeField] PanelController pc;
    [SerializeField] ScoreController sc;

    string coins100 = "1";
    string coins500 = "2";
    string coins1000 = "3";

    string booter1 = "4";
    string booter5 = "5";
    string booter10 = "6";

    int StashCoins = 0;
    int StashBoosters = 0;

    [SerializeField] TextMeshProUGUI StashCoinsText;
    [SerializeField] TextMeshProUGUI StashBoostersText;

    [SerializeField] GameObject AddCoinsToGameButton;
    [SerializeField] GameObject AddBoostersToGameButton;

    [SerializeField] GameObject Restore;

    void Start()
    {
        StashCoins = PlayerPrefs.GetInt("StashCoins");
        StashBoosters = PlayerPrefs.GetInt("StashBoosters");
        updateCoinsAndBoosters();

        DisableRestoreButton();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == "1") addStashCoins(100);

        if (product.definition.id == "2") addStashCoins(500);

        if (product.definition.id == "3") addStashCoins(1000);

        if (product.definition.id == "4") addStashBoosters(1);

        if (product.definition.id == "5") addStashBoosters(5);

        if (product.definition.id == "6") addStashBoosters(10);
    }

    public void addStashCoins(int amount) { StashCoins += amount; PlayerPrefs.SetInt("StashCoins", StashCoins); updateCoinsAndBoosters(); }
    public void removeStashCoins(int amount) { StashCoins -= amount; PlayerPrefs.SetInt("StashCoins", StashCoins); updateCoinsAndBoosters(); }
    public int getStashCoins() { return StashCoins; }

    public void addStashBoosters(int amount) { StashBoosters += amount; PlayerPrefs.SetInt("StashBoosters", StashBoosters); updateCoinsAndBoosters(); }
    public void removeStashBoosters(int amount) { StashBoosters -= amount; PlayerPrefs.SetInt("StashBoosters", StashBoosters); updateCoinsAndBoosters(); }
    public int getStashBoosters() {  return StashBoosters; }

    public void updateCoinsAndBoosters()
    {
        StashCoinsText.text = "Coins: " + StashCoins.ToString();
        StashBoostersText.text = "Boosters: " + StashBoosters.ToString();

        if (StashCoins <= 0)
            AddCoinsToGameButton.GetComponent<Button>().interactable = false;
        else
            AddCoinsToGameButton.GetComponent<Button>().interactable = true;

        if(StashBoosters <= 0)
            AddBoostersToGameButton.GetComponent<Button>().interactable = false;
        else
            AddBoostersToGameButton.GetComponent<Button>().interactable = true;
    }

    void DisableRestoreButton()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
            Restore.SetActive(true);
    }

    public void OpenShop(int index)
    {
        pc.OpenTint(2);
        pc.OpenShopPanels(index);
    }
    public void useCoins()
    {
        if(StashCoins >= 10)
        {
            sc.increaseCoins(10);
            removeStashCoins(10);
        }
        else
        {
            sc.increaseCoins(getStashCoins());
            removeStashCoins(getStashCoins());
        }

        pc.CloseTint();
    }
    public void useBooster()
    {
        if (StashCoins >= 1)
        {
            sc.setLuck(1.5f);
            sc.setLuckTimer(60);
            removeStashBoosters(1);
            pc.CloseTint();
        }
    }
}
