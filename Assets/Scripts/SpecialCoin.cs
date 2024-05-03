using UnityEngine;

public class SpecialCoin : MonoBehaviour
{
    bool didHeGotTheSpecialCoin = false;

    public bool getSpecialCoin() { return didHeGotTheSpecialCoin; }
    public void setSpecialCoin(bool state) { didHeGotTheSpecialCoin = state; }
}
