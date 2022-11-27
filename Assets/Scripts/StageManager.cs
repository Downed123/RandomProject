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
        this.StartStage();
    }

    public void StartStage()
    {
        foreach(EnemyStats enemyStats in _enemyStageStats) {
            StartCoroutine(this.RunEnemyThread(enemyStats));
        }
    }

    private IEnumerator RunEnemyThread(EnemyStats enemyStats)
    {
        yield return new WaitForSeconds(enemyStats.spawnTime);

        for(int i = 0; i < enemyStats.quantity; i++) {
            StartCoroutine(this.RunInstances(enemyStats, i));
        }
    }

    private IEnumerator RunInstances(EnemyStats enemyStats, int num)
    {
        GameObject enemy = Instantiate(enemyStats.obj);
        enemy.transform.position = _player.position + new Vector3(0f, 10f, 0f);

        float step = Time.deltaTime * 20f;

        Vector3 target = this.GetInitialPosition(enemyStats, num);

        while(enemy.transform.position != target)
        {
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, target, step);
            yield return null;
        }
            
        enemy.transform.GetComponent<EnemyController>().StartAi(enemyStats);
    }

    private Vector3 GetInitialPosition(EnemyStats enemyStats, int num)
    {
        Vector3 pos = Vector3.zero;

        if(enemyStats.alignmentMode == AlignmentMode.Horizontal)
        {
            float left = enemyStats.center.x - (enemyStats.range / 2);

            float spaceBetween = enemyStats.range / (enemyStats.quantity - 1);
            
            pos = new Vector3(left + num * spaceBetween, enemyStats.center.y, enemyStats.center.z);

        } else if(enemyStats.alignmentMode == AlignmentMode.Circular)
        {
            float radians = 2 * Mathf.PI / enemyStats.quantity * num;

            float vertical = Mathf.Sin(radians);
            float horizontal = Mathf.Cos(radians);

            Vector3 spawnDir = new Vector3(horizontal, vertical, 0);

            pos = enemyStats.center + spawnDir * enemyStats.range;
        }

        return pos;
    }
}