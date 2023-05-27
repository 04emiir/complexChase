using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float time = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        float seconds = Mathf.FloorToInt(time % 60);
        var segundos = string.Format("{00}", seconds);
        timer.text = "Sobrevive " + segundos + " segundos";

        if(time==0f) {
            timer.text = "Sobreviste";
        }
    }
}
