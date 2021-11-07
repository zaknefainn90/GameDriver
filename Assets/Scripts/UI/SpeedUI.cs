using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameUI
{
    public class SpeedUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI speedLabel;
        private int speed;

        public int Speed
        {
            get { return speed; }
            set
            {
                speed = value;
                speedLabel.text = "SPEED: " + speed + "%";
                SwitchColorBySpeed();
            }
        }

        private void SwitchColorBySpeed()
        {
            if (speed > 100)
            {
                speedLabel.color = Color.blue;
            }
            else if (speed < 100)
            {
                speedLabel.color = Color.red;
            }
            else
            {
                speedLabel.color = Color.white;
            }
        }

        public float CalcMoveSpeedToSpeedPercent(float basicSpeed, float differenceSpeed)
        {
            return (differenceSpeed / basicSpeed) * 100;
        }
    }
}