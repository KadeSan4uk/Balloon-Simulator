using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _spaceBlow;
    [SerializeField] private GameObject _brethingLevel;
    [SerializeField] private Transform _balloon;
    [SerializeField] private Button _spaceButton;

    public Breathing breathing;
    public Balloon balloon;

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
        _balloon.gameObject.SetActive(false);
        _gameOverPanel.SetActive(true);
        _spaceBlow.SetActive(false);
        _brethingLevel.SetActive(false);
        GameTimer();
    }

    public bool IsGameOver() => _isGameOver;    

    private void GameTimer()
    {
        float gameTime = Time.time - _startTime;
        _textMeshProUGUI.text = Mathf.RoundToInt(gameTime).ToString() + " sec.";
    }

    public void RestartGame()
    {
        InputManager.Instance._onClickButton = false;
        _gameOverPanel.SetActive(false);
        _spaceBlow.SetActive(true);
        balloon.IsGameStarted = false;
        _balloon.gameObject.SetActive(true);
        _balloon.localScale = Vector3.one;
        _brethingLevel.SetActive(true);
        breathing.transform.localScale = breathing.startScale;
        _startTime = Time.time;
        _isGameOver = false;
    }
}
