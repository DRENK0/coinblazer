using UnityEngine;
using TMPro;
using System.Collections;

public class InfoController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InfoText;

    public void dislayInfo(string info)
    {
        InfoText.gameObject.SetActive(true);
        InfoText.gameObject.GetComponent<Animator>().SetTrigger("Play");
        InfoText.text = info;

        StartCoroutine(disableText());
    }
    IEnumerator disableText()
    {
        yield return new WaitForSeconds(1f);

        InfoText.gameObject.SetActive(false);
        InfoText.text = "";
    }
}
