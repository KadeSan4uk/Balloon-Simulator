using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _spaceBlow;
    [SerializeField] private GameObject _brethingLevel;

    private float _startTime;


    private bool _isGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _gameOverPanel.SetActive(false);
        _startTime = Time.time;
    }

    public void EndGame()
    {
        _isGameOver = true;
        _gameOverPanel.SetActive(true);
        _spaceBlow.SetActive(false);
        _brethingLevel.SetActive(false);
        GameTimer();
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

    private void GameTimer()
    {
        float gameTime = Time.time - _startTime;
        _textMeshProUGUI.text = Mathf.RoundToInt(gameTime).ToString() + " sec.";
    }

    public void RestartGame()
    {
        _gameOverPanel.SetActive(false);
        _startTime = Time.time;
        Debug.Log("Time is 1");
        _isGameOver = false;
    }

}
