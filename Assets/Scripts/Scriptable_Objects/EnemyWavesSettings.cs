

using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "New EnemyWave", menuName = "EnemyWave")]
    public class EnemyWavesSettings: ScriptableObject
    {
        [SerializeField] private float _duration;
        [SerializeField] private int _numberOfInfantry;
        [SerializeField] private int _numberOfArchers;
        [SerializeField] private int _numberOfHeroes;

        public float Duration => _duration;
        public int NumberOfInfantry => _numberOfInfantry;
        public int NumberOfArchers => _numberOfArchers;
        public int NumberOfHeroes => _numberOfHeroes;
    }
}
