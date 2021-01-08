using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Text _coinsCountLabel;
    [SerializeField] private Text _healthCountLabel;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _wallet.CoinsCountChanged += OnCoinsCountChanged;
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _wallet.CoinsCountChanged -= OnCoinsCountChanged;
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnCoinsCountChanged(int coins)
    {
        _coinsCountLabel.text = coins.ToString();
    }

    private void OnHealthChanged(int health)
    {
        _healthCountLabel.text = health.ToString();
    }
}
