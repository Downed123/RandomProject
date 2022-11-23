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
        public Vector3 center;
        public float range;
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

        for(int i = 0; i < enemyStats.quantity; i++) {
            GameObject enemy = Instantiate(enemyStats.obj);
            enemy.transform.position = _player.position + new Vector3(0f, 10f, 0f);

            float step = Time.deltaTime * 20f;

            StartCoroutine(MoveTowards(enemy.transform, enemyStats, i, step));
        }
    }

    private IEnumerator MoveTowards(Transform current, EnemyStats enemyStats, float count, float maxDistanceDelta)
    {
        Vector3 target = enemyStats.center + new Vector3(count * 2, 0, 0);

        while(current.position != target)
        {
            current.position = Vector3.MoveTowards(current.position, target, maxDistanceDelta);
            yield return null;
        }
        
        current.GetComponent<EnemyController>().StartAi(enemyStats.range);
    }
}