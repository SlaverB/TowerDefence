using Game;
using Scriptable_Objects;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Components.PopUps
{
    class BuyTowersPopups: MonoBehaviour
    {
        [SerializeField] private Button _buyArcherTowerButton;
        [SerializeField] private Button _buySwordsTowerButton;
        [SerializeField] private Button _buyStoneTowerButton;
        [SerializeField] private Button _buyMagicTowerButton;

        [SerializeField] private TowerSettings _archerTower;
        [SerializeField] private TowerSettings _swordsTower;
        [SerializeField] private TowerSettings _stoneTower;
        [SerializeField] private TowerSettings _magicTower;

        public static Action<string> BuildTower;

        private UIController _uIController;
       
        private readonly string _archerTowerPrefabPath = "Prefabs/ArcherTower";
        private readonly string _swordsTowerPrefabPath = "Prefabs/SwordsTower";
        private readonly string _stoneTowerPrefabPath = "Prefabs/StoneTower";
        private readonly string _magicTowerPrefabPath = "Prefabs/MagicTower";

        private void OnEnable()
        {
            _buyArcherTowerButton.onClick.AddListener(BuyArcherTower);
            _buySwordsTowerButton.onClick.AddListener(BuySwordsTower);
            _buyStoneTowerButton.onClick.AddListener(BuyStoneTower);
            _buyMagicTowerButton.onClick.AddListener(BuyMagicTower);
        }

        private void BuyArcherTower()
        {
            if (CheckMoney(_archerTower.BuildPrice))
            {
                BuildTower?.Invoke(_archerTowerPrefabPath);
                Destroy(gameObject);
            }
        }
        private void BuySwordsTower()
        {
            if (CheckMoney(_swordsTower.BuildPrice))
            {
                BuildTower?.Invoke(_swordsTowerPrefabPath);
                Destroy(gameObject);
            }
        }
        private void BuyStoneTower()
        {
            if (CheckMoney(_stoneTower.BuildPrice))
            {
                BuildTower?.Invoke(_stoneTowerPrefabPath);
                Destroy(gameObject);
            }
        }
        private void BuyMagicTower()
        {
            if (CheckMoney(_magicTower.BuildPrice))
            {
                BuildTower?.Invoke(_magicTowerPrefabPath);
                Destroy(gameObject);
            }
        }

        private bool CheckMoney(int price)
        {
            if (price <= GameController.CountCoins)
            {
                GameController.CountCoins -= price;
                return true;
            }
            else
            {
                Debug.Log("You couldn`t buy");
                return false;
            }
        }
    }
}
