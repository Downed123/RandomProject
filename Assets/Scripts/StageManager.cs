using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Globals;

public class StageManager : MonoBehaviour
{   

    [SerializeField] private Transform _player;
    [SerializeField] private List<EnemyStats> _enemyStageStats;

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

    private IEnumerator MoveTowards(Transform current, EnemyStats enemyStats, int count, float maxDistanceDelta)
    {
        Vector3 target = this.GetInitialPosition(enemyStats, count);

        while(current.position != target)
        {
            current.position = Vector3.MoveTowards(current.position, target, maxDistanceDelta);
            yield return null;
        }
        
        current.GetComponent<EnemyController>().StartAi(enemyStats);
    }

    private Vector3 GetInitialPosition(EnemyStats enemyStats, int count)
    {
        Vector3 pos = Vector3.zero;

        if(enemyStats.alignmentMode == AlignmentMode.Horizontal)
        {
            pos = enemyStats.center + new Vector3(count * 2, 0, 0);
        } else if(enemyStats.alignmentMode == AlignmentMode.Circular)
        {
            float radians = 2 * Mathf.PI / enemyStats.quantity * count;

            float vertical = Mathf.Sin(radians);
            float horizontal = Mathf.Cos(radians);

            Vector3 spawnDir = new Vector3(horizontal, vertical, 0);

            pos = enemyStats.center + spawnDir * enemyStats.range;
        }

        return pos;
    }
}