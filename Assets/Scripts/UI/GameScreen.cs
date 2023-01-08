using System;
using States;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _restartButton;

        public static event Action onGameRestart;

        private void Start()
        {
            _restartButton.onClick.AddListener(Restart);
            DestroySticksState.onScoreChange += SetScore;
        }

        private void Restart()
        {
            onGameRestart?.Invoke();
            _score.text = 0.ToString();
        }

        public void SetScore(int value)
        {
            var score = int.Parse(_score.text);
            _score.text = (score + value).ToString();
        }
    }
}