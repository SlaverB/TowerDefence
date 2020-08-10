using Scriptable_Objects;
using UnityEngine;

namespace Tower
{
    class TowerController : MonoBehaviour
    {
        [SerializeField] private TowerSettings _towerSettings;
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _сannonball;
        [SerializeField] private Transform _firePoint;

        private float _rangeRadius;
        private float _shootInterval;
        private int _damage;
        private string enemyTag = "Enemy";

        private float _fireRate = 2f;

        private void Awake()
        {
            _rangeRadius = _towerSettings.RangeRadius;
            _shootInterval = _towerSettings.ShootInterval;
            _damage = _towerSettings.Damage;
        }

        private void Start()
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }

        private void UpdateTarget()
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
            float shortestDistance = Mathf.Infinity;
            GameObject nearestEnemy = null;
            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy; 
                }
            }

            if (nearestEnemy != null && shortestDistance <= _rangeRadius)
            {
                _target = nearestEnemy.transform;
            }
            else
            {
                _target = null;
            }
        }

        private void Update()
        {
            if (_target == null)
            {
                return; 
            }

            if (_shootInterval <= 0f)
            {
                Shoot();
                _shootInterval = 1f / _fireRate;
            }

            _shootInterval -= Time.deltaTime;
        }

        private void Shoot()
        {
            GameObject bulletGO = Instantiate(_сannonball, _firePoint.position, _firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();

            bullet.Damage = _damage;

            if (bullet != null)
            {
                bullet.CatchEnemy( _target);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _rangeRadius);
        }
    }
}
