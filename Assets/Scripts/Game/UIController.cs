using Enemy;
using TMPro;
using Tower;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    class UIController: MonoBehaviour
    {
        [SerializeField] private Transform _uIBG;
        [SerializeField] private GameController _gameController;
        [SerializeField] private TextMeshProUGUI _countCoinstext;
        [SerializeField] private TextMeshProUGUI _numberOfWavetext;
        [SerializeField] private TextMeshProUGUI _healthAmounttext;

        private GameObject _buyTowersPopUp;
        private readonly string _buildTowerPrefabPath = "Prefabs/PopUps/BuyTowersPopUp";

        private void Start()
        {
            TowerPlace.ClickOnTowerPlace += ShowBuyTowersPopUp;
            GameController.CountCoinChanged += UpdateCountCoinText;
            WaveGenerator.NewWaveStarted += UpdateNumberOfWavetext;
            EnemyController.EnemyInCastle += UpdateHealthAmounttext;
            GameController.GameOver += ShowGameOverPopUp;
        }


        private void ShowBuyTowersPopUp()
        {
            if (_buyTowersPopUp != null)
            {
                Destroy(_buyTowersPopUp);
            }
            _buyTowersPopUp = (GameObject)Instantiate(Resources.Load(_buildTowerPrefabPath), _uIBG);
            _buyTowersPopUp.transform.localScale = Vector3.one;
            _buyTowersPopUp.transform.position = _gameController.TowerPlacePosition.position;
        }

        private void DestroyBuyTowersPopUp()
        {
            Destroy(_buyTowersPopUp);
        }
        private void OnEnable()
        {
            UpdateCountCoinText();
        }
        public void UpdateCountCoinText()
        {
            _countCoinstext.text = GameController.CountCoins.ToString();
        }

        private void UpdateNumberOfWavetext(int numberOfWave)
        {
            numberOfWave += 1;
            _numberOfWavetext.text = "Wave " + numberOfWave.ToString() + "/5";
        }

        private void UpdateHealthAmounttext()
        {
            _healthAmounttext.text = _gameController.PlayerHealthAmount.ToString();
        }

        private void ShowGameOverPopUp()
        {
            Debug.Log("GameOver");
        }
    }
}
