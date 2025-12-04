using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    [SerializeField] private float _countdownTime = 60f;
    private float _currentTime;
    private bool _isCountingDown = false;
    [SerializeField] private Text _countdownText;
    [SerializeField] private Transform _gameOverScreen;

    void Awake()
    {
        _countdownText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (_isCountingDown)
        {
            _currentTime -= Time.deltaTime;
            _countdownText.text = Mathf.Ceil(_currentTime).ToString();
            if (_currentTime <= 0)
            {
                _isCountingDown = false;
                OnCountdownFinished();
            }
        }
    }

    public void StartCountdown()
    {
        _currentTime = _countdownTime;
        _isCountingDown = true;
        _countdownText.enabled = true;
    }

    private void OnCountdownFinished()
    {
        _gameOverScreen.gameObject.SetActive(true);
    }
}
