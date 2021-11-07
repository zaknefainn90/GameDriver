using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverScript : MonoBehaviour
{
    [Header("Movment")]
    [SerializeField] private float steerSpeed = 100f;

    [SerializeField] private float basicMoveSpeed = 20f;

    [Header("Buffs")]
    [SerializeField] private float buffTimerDefault = 3;

    private float buffTimerCurrent;
    private float currentMoveSpeed;
    private bool buffTimerStar = false;
    private HpUI hpUI;
    private SpeedUI SpeedUI;

    private void Awake()
    {
        currentMoveSpeed = basicMoveSpeed;
        buffTimerCurrent = buffTimerDefault;
        SpeedUI = FindObjectOfType<SpeedUI>();
    }

    private void Start()
    {
        hpUI = FindObjectOfType<HpUI>();
    }

    private void Update()
    {
        MoveCar();
        BuffTimer();
    }

    private void MoveCar()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveDirection = Input.GetAxis("Vertical") * currentMoveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveDirection, 0);
    }

    private void BuffTimer()
    {
        if (buffTimerStar)
        {
            if (buffTimerCurrent > 0)
            {
                buffTimerCurrent -= Time.deltaTime;
            }
            else
            {
                ResetBuffTimer();
            }
        }
        Debug.Log(buffTimerCurrent);
    }

    private void ResetBuffTimer()
    {
        buffTimerStar = false;
        buffTimerCurrent = buffTimerDefault;
        SpeedUI.Speed = 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hpUI.getHit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Buff")
        {
            StartBuffTimer();
            HandleBuff(other);
        }
    }

    private void StartBuffTimer()
    {
        buffTimerStar = true;
        buffTimerCurrent = buffTimerDefault;
    }

    private void HandleBuff(Collider2D other)
    {
        Buffs buff = other.gameObject.GetComponent<Buffs>();

        currentMoveSpeed = buff.CalcCurrentMovment(basicMoveSpeed);
        buff.DestroyBuff();
    }
}