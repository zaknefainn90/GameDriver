using GameUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class TogglePackage : MonoBehaviour
    {
        private SpriteRenderer packageSpriteRenderer;
        private bool hasPackage;
        private ScoreUI CurrentScore;

        private void Awake()
        {
            CurrentScore = FindObjectOfType<ScoreUI>();
            packageSpriteRenderer = gameObject.transform.Find("InPackage").gameObject.GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            packageSpriteRenderer.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Package" && !hasPackage)
            {
                PickUpPackage(collision);
                ResetPicUpTimer("DROP");
            }
            if (collision.tag == "Customer" && hasPackage)
            {
                PutDownPackage();
                AddScorePoint();
                ResetPicUpTimer("PICK");
            }
        }

        private void ResetPicUpTimer(string activity)
        {
            TimeLeftUI timer = FindObjectOfType<TimeLeftUI>();
            timer.SliderValue = 0f;
            timer.TimerLabelText = "TIME TO " + activity + " PACKAGE";
        }

        private void AddScorePoint()
        {
            int actualScore = CurrentScore.Score;
            CurrentScore.Score = actualScore + 1;
        }

        private void PutDownPackage()
        {
            hasPackage = false;
            packageSpriteRenderer.enabled = false;
        }

        private void PickUpPackage(Collider2D collision)
        {
            Destroy(collision.gameObject);
            packageSpriteRenderer.enabled = true;
            hasPackage = true;
        }
    }
}