using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] clips;

    // 0 - ButtonClick; 1 - CoinSpawn; 2 - CoinLost; 3 - CoinGotten; 4 - superCoin; 5 - Special
    public void PlaySound(int index) { audio.PlayOneShot(clips[index]); }
}
