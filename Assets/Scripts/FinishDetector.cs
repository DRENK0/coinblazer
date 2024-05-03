using System.Collections;
using UnityEngine;

public class FinishDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish")
        {
            ScoreController sc = FindObjectOfType<ScoreController>();
            InfoController ic = FindObjectOfType<InfoController>();
            GameController gc = FindObjectOfType<GameController>();
            CoinSpawnController csc = FindObjectOfType<CoinSpawnController>();
            SoundController sound = FindObjectOfType<SoundController>();

            if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 1)
            {
                sc.increaseCoins(2);

                ic.dislayInfo("1 Extra Coin!");

                sound.PlaySound(3);
            }
            else if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 2)
            {
                ic.dislayInfo("Lost 1 Coin!");

                sound.PlaySound(3);
            }
            else if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 3)
            {
                sc.decreaseCoins(1);

                ic.dislayInfo("Lost 2 Coins!");

                sound.PlaySound(3);
            }
            else if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 4)
            {
                sc.increaseCoins(1);

                sc.removeScore((int)(sc.getScore() * 0.1f));

                ic.dislayInfo("Lost 10% of Your Score!");

                sound.PlaySound(3);
            }
            else if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 5)
            {
                sc.increaseCoins(1);

                csc.spawnThreeCoins();

                sc.setLuck(1.5f);
                sc.setLuckTimer(60);

                ic.dislayInfo("1.5x More Luck!");

                sound.PlaySound(3);
            }
            else if (this.gameObject.GetComponentInParent<Coin>().hasEffect == 6)
            {
                SpecialCoin special = FindObjectOfType<SpecialCoin>();

                special.setSpecialCoin(true);

                sc.increaseCoins(1);

                sc.addScore(990);

                sound.PlaySound(5);
            }
            else
            {
                sc.increaseCoins(1);
                sound.PlaySound(3);
            }

            sc.addScore(10);

            if (sc.getCoins() <= 0 && !gc.getIsLost())
                gc.resetTimer();


            StartCoroutine(destroyCoin(this.gameObject.transform.parent.gameObject));
        }

        if (other.gameObject.tag == "End")
        {
            SoundController sound = FindObjectOfType<SoundController>();
            sound.PlaySound(2);

            StartCoroutine(destroyCoin(this.gameObject.transform.parent.gameObject));
        }
    }

    IEnumerator destroyCoin(GameObject g)
    {
        g.GetComponent<Animator>().SetTrigger("DEATH");

        yield return new WaitForSeconds(0.2f);

        Destroy(g);
    }
}
