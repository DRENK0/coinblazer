using UnityEngine;

public class CoinDetector : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.root.tag == "Coin" & !this.gameObject.transform.IsChildOf(other.transform.root) &&
            other.gameObject.GetComponentInParent<Coin>().hasEffect == 0 && this.gameObject.GetComponentInParent<Coin>().hasEffect == 0)
        {
            Vector3 thisGameobject = this.gameObject.transform.root.gameObject.transform.position;
            Vector3 compareOther = other.gameObject.transform.root.transform.position;

            float proximityThreshold = 0.2f;

            float xDifference = Mathf.Abs(thisGameobject.x - compareOther.x);
            float zDifference = Mathf.Abs(thisGameobject.z - compareOther.z);


            if (xDifference < proximityThreshold && zDifference < proximityThreshold)
            {
                CoinsAreOverlaping(this.gameObject.transform.root.gameObject, other.gameObject.transform.root.gameObject);
                this.gameObject.SetActive(false);
            }
        }
    }
    public void CoinsAreOverlaping(GameObject g1, GameObject g2)
    {
        CoinSpawnController csc = FindObjectOfType<CoinSpawnController>();
        ScoreController sc = FindObjectOfType<ScoreController>();

        if (sc.getLuck() == 1.0f)
        {
            int rndm = Random.Range(0, 5);

            if (rndm == 0)
                csc.spawnEmphatyCoin(g1);
            else if (rndm == 1)
                csc.spawnBoostCoin(g1);
            else if (rndm == 2)
                csc.spawnDeathCoin(g1);
            else if (rndm == 3)
                csc.spawnVoidCoin(g1);
            else if (rndm == 4)
                csc.spawnSelfishCoin(g1);
        }
        else if (sc.getLuck() == 1.5f)
        {
            int rndm = Random.Range(0, 7);

            if (rndm == 0 || rndm == 5)
                csc.spawnEmphatyCoin(g1);
            else if (rndm == 1 || rndm == 6)
                csc.spawnBoostCoin(g1);
            else if (rndm == 2)
                csc.spawnDeathCoin(g1);
            else if (rndm == 3)
                csc.spawnVoidCoin(g1);
            else if (rndm == 4)
                csc.spawnSelfishCoin(g1);
        }

        Destroy(g1);
        Destroy(g2);
    }
}
