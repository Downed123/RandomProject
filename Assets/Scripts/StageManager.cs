using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StageManager : MonoBehaviour
{   

    [SerializeField] private Transform _player;
    [SerializeField] private List<EnemyStats> _enemyStageStats;

    [Serializable]
    public struct EnemyStats
    {
        public GameObject obj;
        public int quantity;
        public Vector3 startPosition;
        public float spawnTime;
        public bool spawnsOnce;
        public float delayTime;
    }

    private void Start()
    {
        StartStage();
    }

    public void StartStage()
    {
        foreach(EnemyStats enemyStats in _enemyStageStats) {
            StartCoroutine(RunEnemyThread(enemyStats));
        }
    }

    private IEnumerator RunEnemyThread(EnemyStats enemyStats)
    {
        yield return new WaitForSeconds(enemyStats.spawnTime);

        GameObject enemy = Instantiate(enemyStats.obj);
        enemy.transform.position = _player.position + new Vector3(0f, 10f, 0f);

        float step = Time.deltaTime *20f;

        StartCoroutine(MoveTowards(enemy.transform, enemyStats.startPosition, step));
    }

    private IEnumerator MoveTowards(Transform current, Vector3 target, float maxDistanceDelta)
    {
        while(current.position != target)
        {
            current.position = Vector3.MoveTowards(current.position, target, maxDistanceDelta);
            yield return null;
        }
        
        current.GetComponent<EnemyController>().StartAi();
    }
}