using System;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private int _scoreCount;
    public TMP_Text ScoreText;
    
    public int ScoreCount => _scoreCount;

    private void OnEnable()
    {
        ScoreCollector.OnScoreCollected += IncrementScoreCount;
    }

    private void OnDisable()
    {
        ScoreCollector.OnScoreCollected -= IncrementScoreCount;
    }

    void Start()
    {
        UpdateScoreText();
    }
    
    private void UpdateScoreText()
    {
        ScoreText.text = _scoreCount.ToString();
    }

    private void IncrementScoreCount()
    {
        _scoreCount++;
        UpdateScoreText();
    }
}