using Game;
using Scriptable_Objects;
using System;
using UnityEngine;

namespace Enemy
{
    class EnemyController : MonoBehaviour
    {
        public static Action EnemyInCastle;

        private float _speed;
        private Transform _waypoints;
        private Transform _waypoint;
        private int _waypointIndex = -1;


        void Start()
        {
            _waypoints = GameObject.Find("Waypoints").transform;
            _speed = GetComponent<EnemyView>().Speed;
            NextWaypoint();
        }

        void Update()
        {
            Vector3 dir = _waypoint.transform.position - transform.position;

            float _speed = Time.deltaTime * this._speed;
            transform.Translate(dir.normalized * _speed, Space.World);

            if (dir.magnitude <= _speed)
                NextWaypoint();
        }

        private void NextWaypoint()
        {
            _waypointIndex++;

            if (_waypointIndex >= _waypoints.childCount)
            {
                EnemyInCastle?.Invoke();
                Destroy(gameObject);
                return;
            }

            _waypoint = _waypoints.GetChild(_waypointIndex);
        }

    }
}
