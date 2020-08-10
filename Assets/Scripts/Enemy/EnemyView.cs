using Scriptable_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Enemy
{
    class EnemyView: MonoBehaviour
    {
        [SerializeField] private EnemySettings _enemySettings;

        public float Speed => _enemySettings.MovingSpeed;
        public float HealthAmount
        {
            get
            {
                return _healthAmount;
            }
            set
            {
                _healthAmount = value;
            }
        }

        private float _healthAmount;

        private void Awake()
        {
            _healthAmount = _enemySettings.HealthAmount;
        }
    }
}
