using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
using TMPro;

public class TimeLeftUI : MonoBehaviour
{
    [SerializeField] private float timeSpeed = 50f;
    private Slider timeSlider;
    private TextMeshProUGUI label;

    public float SliderValue
    {
        set
        {
            timeSlider.value = value;
        }
    }

    public string TimerLabelText
    {
        set
        {
            label.text = value;
        }
    }

    private void Awake()
    {
        timeSlider = gameObject.GetComponentInChildren<Slider>();
        label = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        timeSlider.value = timeSlider.value + (0.1f / timeSpeed);
        EndGameIfTimeLeft();
    }

    private void EndGameIfTimeLeft()
    {
        if (timeSlider.value == 1f)
        {
            FindObjectOfType<GameManager>().LoadMenuScene();
        }
    }
}