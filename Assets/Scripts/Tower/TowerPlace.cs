using Game;
using System;
using UnityEngine;

namespace Tower
{
    class TowerPlace : MonoBehaviour
    {
        public static Action ClickOnTowerPlace;

        public Color HoverColor;

        private GameController _gameController;
        private SpriteRenderer _rend;
        private Color _defaultColor;

        private void Awake()
        {
            _gameController = FindObjectOfType<GameController>();
        }
        private void OnEnable()
        {
            _rend = GetComponent<SpriteRenderer>();
            _defaultColor = _rend.color;
        }

        private void OnMouseDown()
        {
            _gameController.TowerPlacePosition = transform;
            ClickOnTowerPlace?.Invoke();
            
        }
        private void OnMouseEnter()
        {
            _rend.color = HoverColor;
        }

        private void OnMouseExit()
        {
            _rend.color = _defaultColor;
        }

    }
}
