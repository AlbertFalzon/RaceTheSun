using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int timerStart = 120;
    Text timerText;
    IEnumerator Start()
    {
        timerText = GetComponent<Text>();
        while (timerStart > 0)
        {
            yield return StartCoroutine(DecreaseTimer());
        }

        if (FindObjectOfType<Player>().returnAlive())
        {
            FindObjectOfType<Level>().loadGameWin();
        }
    }

    private IEnumerator DecreaseTimer()
    {
        timerStart -= 1;
        timerText.text = timerStart.ToString();
        yield return new WaitForSeconds(1);
    }

    public int returnTimer()
    {
        return timerStart;
    }
}
