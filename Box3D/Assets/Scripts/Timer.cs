using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float TimeStart = 10f;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = TimeStart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeStart > 0) {
            TimeStart -= Time.deltaTime;
            TimerText.text = Mathf.Round(TimeStart).ToString();
        }
    }
}
