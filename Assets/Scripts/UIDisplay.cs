using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider   healthSlider;
    [SerializeField] Health   PlayerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI     scoreText;
    ScoreKeeper         scoreKeeper;
    
    int maxZeroes = 8;
    void Awake()
    {
        //health      = FindObjectOfType<Health>();
        //scoreText   = GetComponentInChildren<TextMeshProUGUI>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = PlayerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = PlayerHealth.GetHealth();
        SetScore();
    }

    void SetScore()
    {
        
        string score = scoreKeeper.GetScore().ToString();
        string leadingZeroes = new string('0',maxZeroes - score.Length);        
        scoreText.text =  leadingZeroes + score.ToString();
    }

    void SetHealth()
    {
        
    }
}
