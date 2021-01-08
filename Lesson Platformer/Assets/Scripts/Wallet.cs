using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    private int _coinsCount;

    public UnityAction<int> CoinsCountChanged;

    private void Start()
    {
        CoinsCountChanged?.Invoke(_coinsCount);
    }

    public void AddCoin()
    {
        _coinsCount += 1;
        CoinsCountChanged?.Invoke(_coinsCount);
    }
}
