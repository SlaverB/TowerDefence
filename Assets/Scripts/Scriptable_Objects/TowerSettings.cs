using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
    public class TowerSettings: ScriptableObject
    {
        [SerializeField] private int _buildPrice;
        [SerializeField] private float _rangeRadius;
        [SerializeField] private float _shootInterval;
        [SerializeField] private int _damage;
        [SerializeField] private Sprite _towerSprite;

        public int BuildPrice => _buildPrice;
        public float RangeRadius => _rangeRadius;
        public float ShootInterval => _shootInterval;
        public int Damage => _damage;

    }
}
