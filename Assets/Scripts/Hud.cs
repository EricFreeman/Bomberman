using Assets.Scripts.Events;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Hud : MonoBehaviour, IListener<ObjectBrokenMessage>
    {
        public Text ScoreText;

        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                ScoreText.text = "Score: {0}".ToScoreFormat(value);
            }
        }

        public void Handle(ObjectBrokenMessage message)
        {
            Score += message.Points;
        }
    }
}
