using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
    public class EnemySettings: ScriptableObject
    {
        [SerializeField] private int _healthAmount;
        [SerializeField] private float _movingSpeed;
        [SerializeField] private int _damage;

        public int HealthAmount => _healthAmount;
        public float MovingSpeed => _movingSpeed;
        public int Damage => _damage;
    }
}
