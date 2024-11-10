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
        //Time.timeScale = 0f;
        GameTimer();
    }

    public bool IsGameOver()
    {
        return _isGameOver;
    }

    private void GameTimer()
    {
        float gameTime = Time.time - _startTime;
        _textMeshProUGUI.text = Mathf.RoundToInt(gameTime).ToString()+" sec.";
    }

    public void RestartGame()
    {
        _startTime = Time.time;
        _gameOverPanel.SetActive(false);
        //Time.timeScale = 1f;
        _isGameOver = false;
    }

}
