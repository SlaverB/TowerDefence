using Components.PopUps;
using Enemy;
using System;
using UnityEngine;

namespace Game
{
    class GameController : MonoBehaviour
    {
        [SerializeField] private UIController _uIController;

        public static Action CountCoinChanged;
        public static Action GameOver;

        private Transform _towerPlace;
        private GameObject _tower;
        private int _playerHealthAmount = 5;

        public static int CountCoins
        {
            get
            {
                return PlayerPrefs.GetInt("NumberOfCoins", 0);
            }
            set
            {
                PlayerPrefs.SetInt("NumberOfCoins", value);
                CountCoinChanged?.Invoke();
            }
        }

        public int PlayerHealthAmount
        {
            get
            {
                return _playerHealthAmount;
            }
            set
            {
                _playerHealthAmount = value;
            }
        }

        public static void PlayerGetCoin(int count)
        {
            CountCoins += count;
        }
        public Transform TowerPlacePosition
        {
            get
            {
                return _towerPlace;
            }
            set
            {
                _towerPlace = value;
            }

        }

        private void OnEnable()
        {
            CountCoins = 140;
        }

        private void Start()
        {
            BuyTowersPopups.BuildTower += BuildTower;
            EnemyController.EnemyInCastle += LoseLife;
        }

        public void BuildTower(string pathTowerPrefab)
        {
            _tower = (GameObject)Instantiate(Resources.Load(pathTowerPrefab), _towerPlace.position, _towerPlace.rotation);
            //_tower.transform.localScale = Vector3.one;
            Destroy(_towerPlace.gameObject);
        }

        private void LoseLife()
        {
            if(PlayerHealthAmount > 0)
            {
                PlayerHealthAmount--;
            }
            else if (PlayerHealthAmount == 0)
            {
                GameOver?.Invoke();
            }
        }
    }
}
