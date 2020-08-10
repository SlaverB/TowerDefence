using Enemy;
using Game;
using UnityEngine;

namespace Tower
{
    class Bullet : MonoBehaviour
    {
        private float _speed = 70f;

        public float Damage;

        private Transform _target;
        private float _enemyHealth;


        public void CatchEnemy(Transform target)
        {
            _target = target;
            _enemyHealth = _target.gameObject.GetComponent<EnemyView>().HealthAmount;
        }

        private void Update()
        {
            if (_target == null)
            {
                Destroy(gameObject);
                return;
            }

            Vector3 dir = _target.position - transform.position;
            float distanceInCurrFrame = _speed * Time.deltaTime;

            if (dir.magnitude <= distanceInCurrFrame)
            {
                HitEnemy();
                return;
            }

            transform.Translate(dir.normalized * distanceInCurrFrame, Space.World);
        }

        public void HitEnemy()
        {
            _enemyHealth -= Damage;
            if (_enemyHealth <= 0f)
            {
                Destroy(_target.gameObject);
                GameController.PlayerGetCoin(UnityEngine.Random.Range(5, 10));
            }

            Destroy(gameObject);
        }


    }
}
