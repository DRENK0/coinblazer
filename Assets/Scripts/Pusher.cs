using System.Collections;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField] GameController gc;

    [SerializeField] float lerpDuration = 0.75f;
    [SerializeField] float maxZ = -2.5f;
    [SerializeField] float minZ = 0f;
    bool isMovingForward = true;

    Vector3 startPosition;
    Vector3 endPosition;
    float lerpStartTime;

    bool isWaiting = false;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y, maxZ);
        lerpStartTime = Time.time;
        isWaiting = false;
    }

    void Update()
    {
        if (gc.getIsLost()) return;

        if (!gc.getGameStarted()) return;

        if (!isWaiting)
        {
            float lerpProgress = (Time.time - lerpStartTime) / lerpDuration;
            float easedLerpProgress = Mathf.SmoothStep(0f, 1f, lerpProgress);

            if (isMovingForward)
                transform.position = Vector3.Lerp(startPosition, endPosition, easedLerpProgress);
            else
                transform.position = Vector3.Lerp(endPosition, startPosition, easedLerpProgress);

            if (lerpProgress >= 1f)
            {
                lerpStartTime = Time.time;
                isMovingForward = !isMovingForward;
                checkIfIsAtStart();
            }
        }
    }

    public void checkIfIsAtStart()
    {
        if (this.gameObject.transform.position == startPosition && !isWaiting)
        {
            isWaiting = true;
            StartCoroutine(wait());
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.5f);
        isWaiting = false;
        lerpStartTime = Time.time;
    }
}
