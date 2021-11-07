using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{
    [SerializeField] private BuffScriptableObject buffData;
    private SpeedUI SpeedUI;

    private void Awake()
    {
        SpeedUI = FindObjectOfType<SpeedUI>();
    }

    public float buffValue
    {
        get
        {
            return buffData.boostValue;
        }
    }

    public float CalcCurrentMovment(float basicMoveSpeed)
    {
        if (buffData.type == BuffsType.PowerUp)
        {
            float currentMoveSpeed = basicMoveSpeed + buffData.boostValue;
            SpeedUIBoost(currentMoveSpeed);

            return currentMoveSpeed;
        }
        else
        {
            float currentMoveSpeed = basicMoveSpeed - buffData.boostValue;
            SpeedUIReduced(currentMoveSpeed);

            return currentMoveSpeed;
        }
    }

    private void SpeedUIBoost(float currentMoveSpeed)
    {
        float calcPercentSpeed = SpeedUI.CalcMoveSpeedToSpeedPercent(currentMoveSpeed, buffData.boostValue);
        SpeedUI.Speed = 100 + (int)calcPercentSpeed;
    }

    private void SpeedUIReduced(float currentMoveSpeed)
    {
        float calcPercentSpeed = SpeedUI.CalcMoveSpeedToSpeedPercent(currentMoveSpeed, buffData.boostValue);
        SpeedUI.Speed = 100 - (int)calcPercentSpeed;
    }

    public void ResetSpeedUI()
    {
        SpeedUI.Speed = 100;
    }

    public void DestroyBuff()
    {
        Destroy(gameObject);
    }
}