using Enemy;
using Game;
using Scriptable_Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private EnemyWavesSettings[] _waves;
    [SerializeField] private GameObject _infantry;
    [SerializeField] private GameObject _archers;
    [SerializeField] private GameObject _herous;

    public static Action<int> NewWaveStarted;

    private bool _isWaveFinished;
    private int _numberOfWave = 0;

    public int NumberOfWave
    {
        get
        {
            return _numberOfWave;
        }
        set
        {
            _numberOfWave = value;
            NewWaveStarted?.Invoke(value);
        }
    }

    void Start()
    {
        GameController.GameOver += StopWaves;
        StartCoroutine(SpawnWave());
    }


    void Update()
    {
        if(_isWaveFinished && FindObjectOfType<EnemyController>() == null)
        {
            _isWaveFinished = false;
            StartCoroutine(SpawnWave());
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < _waves[NumberOfWave].NumberOfArchers; i++)
        {
            SpawnEnemy(_archers);
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < _waves[NumberOfWave].NumberOfInfantry; i++)
        {
            SpawnEnemy(_infantry);
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < _waves[NumberOfWave].NumberOfArchers; i++)
        {
            SpawnEnemy(_herous);
            yield return new WaitForSeconds(1f);
        }

        NumberOfWave += 1;
        _isWaveFinished = true;
        yield return new WaitForSeconds(3f);
    }

    private void SpawnEnemy(GameObject obj)
    {
        Instantiate(obj.transform, transform.position, transform.rotation);
    }

    private void StopWaves()
    {
        StopAllCoroutines();
    }
}
