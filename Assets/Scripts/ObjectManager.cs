using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject BossPrefab;
    public GameObject enemyLPrefab;
    public GameObject enemyMPrefab;
    public GameObject enemySPrefab;
    public GameObject itemCoinPrefab;
    public GameObject itemPowerPrefab;
    public GameObject itemBoomPrefab;
    public GameObject bulletPlayerAPrefab;
    public GameObject bulletPlayerBPrefab;
    public GameObject bulletEnemyAPrefab;
    public GameObject bulletEnemyBPrefab;
    public GameObject bulletBossAPrefab;
    public GameObject bulletBossBPrefab;
    public GameObject explosionPrefab;


    GameObject[] Boss;
    GameObject[] enemyL;
    GameObject[] enemyM;
    GameObject[] enemyS;

    GameObject[] itemCoin;
    GameObject[] itemPower;
    GameObject[] itemBoom;

    GameObject[] bulletPlayerA;
    GameObject[] bulletPlayerB;
    GameObject[] bulletEnemyA;
    GameObject[] bulletEnemyB;
    GameObject[] bulletBossA;
    GameObject[] bulletBossB;
    GameObject[] explosion;

    GameObject[] targetPool;

    void Awake()
    {
        Boss = new GameObject[1];
        enemyL = new GameObject[10];
        enemyM = new GameObject[10];
        enemyS = new GameObject[20];

        itemCoin = new GameObject[20];
        itemPower = new GameObject[10];
        itemBoom = new GameObject[10];

        bulletPlayerA = new GameObject[200];
        bulletPlayerB = new GameObject[200];
        bulletEnemyA = new GameObject[200];
        bulletEnemyB = new GameObject[1000];
        bulletBossA = new GameObject[200];
        bulletBossB = new GameObject[200];

        explosion = new GameObject[20];

        Generate();
    }

    void Generate()
    {
        for (int idx = 0; idx < Boss.Length; idx++)
        {
            Boss[idx] = Instantiate(BossPrefab);
            Boss[idx].SetActive(false);
        }
        for (int idx = 0; idx < enemyL.Length; idx++)
        {
            enemyL[idx] = Instantiate(enemyLPrefab);
            enemyL[idx].SetActive(false);
        }
        for (int idx = 0; idx < enemyM.Length; idx++)
        {
            enemyM[idx] = Instantiate(enemyMPrefab);
            enemyM[idx].SetActive(false);
        }
        for (int idx = 0; idx < enemyS.Length; idx++)
        {
            enemyS[idx] = Instantiate(enemySPrefab);
            enemyS[idx].SetActive(false);
        }

        for (int idx = 0; idx < itemCoin.Length; idx++)
        {
            itemCoin[idx] = Instantiate(itemCoinPrefab);
            itemCoin[idx].SetActive(false);
        }
        for (int idx = 0; idx < itemPower.Length; idx++)
        {
            itemPower[idx] = Instantiate(itemPowerPrefab);
            itemPower[idx].SetActive(false);
        }
        for (int idx = 0; idx < itemBoom.Length; idx++)
        {
            itemBoom[idx] = Instantiate(itemBoomPrefab);
            itemBoom[idx].SetActive(false);
        }

        for (int idx = 0; idx < bulletPlayerA.Length; idx++)
        {
            bulletPlayerA[idx] = Instantiate(bulletPlayerAPrefab);
            bulletPlayerA[idx].SetActive(false);
        }
        for (int idx = 0; idx < bulletPlayerB.Length; idx++)
        {
            bulletPlayerB[idx] = Instantiate(bulletPlayerBPrefab);
            bulletPlayerB[idx].SetActive(false);
        }
        for (int idx = 0; idx < bulletEnemyA.Length; idx++)
        {
            bulletEnemyA[idx] = Instantiate(bulletEnemyAPrefab);
            bulletEnemyA[idx].SetActive(false);
        }
        for (int idx = 0; idx < bulletEnemyB.Length; idx++)
        {
            bulletEnemyB[idx] = Instantiate(bulletEnemyBPrefab);
            bulletEnemyB[idx].SetActive(false);
        }
        for (int idx = 0; idx < bulletBossA.Length; idx++)
        {
            bulletBossA[idx] = Instantiate(bulletBossAPrefab);
            bulletBossA[idx].SetActive(false);
        }
        for (int idx = 0; idx < bulletBossB.Length; idx++)
        {
            bulletBossB[idx] = Instantiate(bulletBossBPrefab);
            bulletBossB[idx].SetActive(false);
        }
        for (int idx = 0; idx < explosion.Length; idx++)
        {
            explosion[idx] = Instantiate(explosionPrefab);
            explosion[idx].SetActive(false);
        }
    }

    public GameObject MakeObj(string type)
    {
        switch (type)
        {
            case "Boss":
                targetPool = Boss;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "Explosion":
                targetPool = explosion;
                break;
        }

        for (int idx = 0; idx < targetPool.Length; idx++)
        {
            if (!targetPool[idx].activeSelf)
            {
                targetPool[idx].SetActive(true);
                return targetPool[idx];
            }
        }

        return null;
    }

    public GameObject[] GetPool(string type)
    {
        switch (type)
        {
            case "Boss":
                targetPool = Boss;
                break;
            case "EnemyL":
                targetPool = enemyL;
                break;
            case "EnemyM":
                targetPool = enemyM;
                break;
            case "EnemyS":
                targetPool = enemyS;
                break;
            case "ItemCoin":
                targetPool = itemCoin;
                break;
            case "ItemBoom":
                targetPool = itemBoom;
                break;
            case "ItemPower":
                targetPool = itemPower;
                break;
            case "BulletPlayerA":
                targetPool = bulletPlayerA;
                break;
            case "BulletPlayerB":
                targetPool = bulletPlayerB;
                break;
            case "BulletEnemyA":
                targetPool = bulletEnemyA;
                break;
            case "BulletEnemyB":
                targetPool = bulletEnemyB;
                break;
            case "BulletBossA":
                targetPool = bulletBossA;
                break;
            case "BulletBossB":
                targetPool = bulletBossB;
                break;
            case "Explosion":
                targetPool = explosion;
                break;
        }

        return targetPool;
    }
}
