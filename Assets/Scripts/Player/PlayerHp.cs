using Core;
using GameUI;
using UnityEngine;
using TMPro;

namespace Player
{
    public class PlayerHp : MonoBehaviour
    {
        private HpUI hpUI;

        private void Awake()
        {
            hpUI = FindObjectOfType<HpUI>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            hpUI.getHit();
        }
    }
}