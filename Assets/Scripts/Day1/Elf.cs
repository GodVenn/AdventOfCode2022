using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace Assets.Scripts.Day1
{
    internal class Elf : MonoBehaviour
    {
        public GameObject UIPrefab;
        public Sprite DeadSprite;

        private Canvas _canvas;

        public TextMeshProUGUI ScoreText { get; private set; }

        private int _score = 0;
        public int Score 
        { 
            get {
                return _score;
            }
            set {
                _score = value;
                if(_score <= 0)
                {
                    _score = 0;
                    GetComponent<SpriteRenderer>().sprite = DeadSprite;
                }
                ScoreText.text = _score.ToString();
            } 
        }

        void Awake()
        {
            _canvas = FindObjectOfType<Canvas>();
            var ui = Instantiate(UIPrefab, _canvas.gameObject.transform);
            ui.GetComponent<UIFollowObject>().target = gameObject;
            ScoreText = ui.GetComponent<TextMeshProUGUI>();
        }
    }
}
