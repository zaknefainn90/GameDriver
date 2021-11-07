using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;

public class HpUI : MonoBehaviour
{
    private List<GameObject> hpImages = new List<GameObject>();
    private int lastHpActiveIndex;
    private bool isBlocked = false;

    private void Awake()
    {
        GetHpGameObjectsToList();
        lastHpActiveIndex = hpImages.Count;
    }

    private void GetHpGameObjectsToList()
    {
        foreach (Transform child in transform)
        {
            hpImages.Add(child.gameObject);
        }
    }

    public void getHit()
    {
        bool isHpGreatherThanZero = lastHpActiveIndex >= 0;

        if (isHpGreatherThanZero)
        {
            StartCoroutine(DownHpWithTimeout());
            EndGameWhenZeroHp();
        }
    }

    private IEnumerator DownHpWithTimeout()
    {
        if (!isBlocked)
        {
            isBlocked = true;
            hpImages[lastHpActiveIndex - 1].SetActive(false);
            lastHpActiveIndex--;
        }
        yield return new WaitForSeconds(0.1f);
        isBlocked = false;
    }

    private void EndGameWhenZeroHp()
    {
        if (lastHpActiveIndex == 0)
        {
            FindObjectOfType<GameManager>().LoadMenuScene();
        }
    }
}