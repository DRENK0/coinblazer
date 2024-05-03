using UnityEngine;

public class CoinSpawnController : MonoBehaviour
{
    [SerializeField] Pusher p;
    [SerializeField] InfoController ic;
    [SerializeField] ScoreController sc;
    [SerializeField] SoundController sound;

    [Space]

    [SerializeField] GameObject DefaultCoin;
    [SerializeField] GameObject EmphatyCoin;
    [SerializeField] GameObject DeathCoin;
    [SerializeField] GameObject VoidCoin;
    [SerializeField] GameObject SelfishCoin;
    [SerializeField] GameObject BoostCoin;

    [Space]

    [SerializeField] GameObject SpecialCoin;

    [SerializeField] Transform[] SpawnLocs;

    public void spawnCoin()
    {
        if(sc.getCoins() > 0)
        {
            int rndmLoc = Random.Range(0, SpawnLocs.Length);
            int rndmSize = Random.Range(0, 3);

            int special = Random.Range(0,1000);

            GameObject c = null;

            if (special == 0)
                c = Instantiate(SpecialCoin, SpawnLocs[rndmLoc].transform.position, Quaternion.identity);
            else
                c = Instantiate(DefaultCoin, SpawnLocs[rndmLoc].transform.position, Quaternion.identity);

            if (rndmSize == 0)
            {
                c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
                c.gameObject.GetComponent<Animator>().SetTrigger("S");
            }
            else if(rndmSize == 1)
            {
                c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
                c.gameObject.GetComponent<Animator>().SetTrigger("M");
            }
            else if( rndmSize == 2)
            {
                c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
                c.gameObject.GetComponent<Animator>().SetTrigger("L");
            }
        }
        sound.PlaySound(1);
    }
    public void spawnThreeCoins()
    {
        GameObject c1 = Instantiate(DefaultCoin, SpawnLocs[10].transform.position, Quaternion.identity);
        GameObject c2 = Instantiate(DefaultCoin, SpawnLocs[9].transform.position, Quaternion.identity);
        GameObject c3 = Instantiate(DefaultCoin, SpawnLocs[8].transform.position, Quaternion.identity);

        c1.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
        c1.gameObject.GetComponent<Animator>().SetTrigger("S");

        c2.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
        c2.gameObject.GetComponent<Animator>().SetTrigger("S");

        c3.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
        c3.gameObject.GetComponent<Animator>().SetTrigger("S");

        sound.PlaySound(1);
    }
    public void spawnEmphatyCoin(GameObject g)
    {
        GameObject c = Instantiate(EmphatyCoin, g.transform.position, Quaternion.identity);

        int rndmSize = Random.Range(0, 3);

        if (rndmSize == 0)
        {
            c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
            c.gameObject.GetComponent<Animator>().SetTrigger("S");
        }
        else if (rndmSize == 1)
        {
            c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
            c.gameObject.GetComponent<Animator>().SetTrigger("M");
        }
        else if (rndmSize == 2)
        {
            c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            c.gameObject.GetComponent<Animator>().SetTrigger("L");
        }

        sound.PlaySound(4);
    }
    public void spawnDeathCoin(GameObject g)
    {
        GameObject c = Instantiate(DeathCoin, g.transform.position, Quaternion.identity);

        int rndmSize = Random.Range(0, 3);

        if (rndmSize == 0)
        {
            c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
            c.gameObject.GetComponent<Animator>().SetTrigger("S");
        }
        else if (rndmSize == 1)
        {
            c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
            c.gameObject.GetComponent<Animator>().SetTrigger("M");
        }
        else if (rndmSize == 2)
        {
            c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            c.gameObject.GetComponent<Animator>().SetTrigger("L");
        }

        sound.PlaySound(4);
    }

    public void spawnVoidCoin(GameObject g)
    {
        GameObject c = Instantiate(VoidCoin, g.transform.position, Quaternion.identity);

        int rndmSize = Random.Range(0, 3);

        if (rndmSize == 0)
        {
            c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
            c.gameObject.GetComponent<Animator>().SetTrigger("S");
        }
        else if (rndmSize == 1)
        {
            c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
            c.gameObject.GetComponent<Animator>().SetTrigger("M");
        }
        else if (rndmSize == 2)
        {
            c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            c.gameObject.GetComponent<Animator>().SetTrigger("L");
        }

        sound.PlaySound(4);
    }

    public void spawnSelfishCoin(GameObject g)
    {
        GameObject c = Instantiate(SelfishCoin, g.transform.position, Quaternion.identity);

        int rndmSize = Random.Range(0, 3);

        if (rndmSize == 0)
        {
            c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
            c.gameObject.GetComponent<Animator>().SetTrigger("S");
        }
        else if (rndmSize == 1)
        {
            c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
            c.gameObject.GetComponent<Animator>().SetTrigger("M");
        }
        else if (rndmSize == 2)
        {
            c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            c.gameObject.GetComponent<Animator>().SetTrigger("L");
        }

        sound.PlaySound(4);
    }

    public void spawnBoostCoin(GameObject g)
    {
        GameObject c = Instantiate(BoostCoin, g.transform.position, Quaternion.identity);

        int rndmSize = Random.Range(0, 3);

        if (rndmSize == 0)
        {
            c.gameObject.transform.localScale = new Vector3(0.2f, 0.3f, 0.2f);
            c.gameObject.GetComponent<Animator>().SetTrigger("S");
        }
        else if (rndmSize == 1)
        {
            c.gameObject.transform.localScale = new Vector3(0.225f, 0.3f, 0.225f);
            c.gameObject.GetComponent<Animator>().SetTrigger("M");
        }
        else if (rndmSize == 2)
        {
            c.gameObject.transform.localScale = new Vector3(0.25f, 0.3f, 0.25f);
            c.gameObject.GetComponent<Animator>().SetTrigger("L");
        }

        sound.PlaySound(4);
    }
}
