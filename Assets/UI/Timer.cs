using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public GameObject textField;
    public int seconds = 0;
    public float timeMultiplier = 1f;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        enemySpawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<EnemySpawner>();
        textField.GetComponent<TextMeshProUGUI>().text = "0:00";
        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            seconds++;
            textField.GetComponent<TextMeshProUGUI>().text = GetTime();
            if (seconds % 60 == 0)
            {
                enemySpawner.AddToMultiplier(.05f);
                enemySpawner.NextEnemy();
                enemySpawner.IncreaseNumberOfEnemies(5);
            }
        }
    }

    private string GetTime()
    {
        string secStr;
        string minStr;
        int min = seconds / 60;
        int sec = seconds % 60;
        if (sec < 10)
        {
            secStr = "0" + sec;
        }
        else
        {
            secStr = sec.ToString();
        }
        minStr = min.ToString();
        return minStr + ":" + secStr;
    }

    private void Update()
    {
        Time.timeScale = timeMultiplier;
    }
}
