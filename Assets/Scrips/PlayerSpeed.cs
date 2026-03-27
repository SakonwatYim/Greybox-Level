using UnityEngine;
using System.Collections;

public class PlayerSpeed : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float moveSpeed;

    void Start()
    {
        moveSpeed = normalSpeed;
    }

    public void SpeedBoost(float boostAmount, float duration)
    {
        StartCoroutine(Boost(boostAmount, duration));
    }

    IEnumerator Boost(float boostAmount, float duration)
    {
        moveSpeed += boostAmount;

        yield return new WaitForSeconds(duration);

        moveSpeed = normalSpeed;
    }
}