using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timer;
    private float elapsedTime = 0f;
    private bool isRunning = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;

            timer.text = string.Format("{0:0}:{1:00}", Mathf.FloorToInt(elapsedTime / 60f), Mathf.FloorToInt(elapsedTime % 60f));
        }
    }
}
