using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    public int score;
    public int power;
    public int maxPower;
    public int boom;
    public int maxBoom;

    public float speed;
    public float maxShotDelay;
    public float curShotDelay;

    public bool isTop, isBottom, isRight, isLeft;
    public bool isHit;
    public bool isBoomTime;
    public bool isRespawnTime;

    public GameObject bulletA;
    public GameObject bulletB;
    public GameObject boomEffect;

    public GameManager gameManager;
    public ObjectManager objectManager;

    Animator anim;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {
        Unbeatable();
        Invoke("Unbeatable", 3);
    }

    void Unbeatable()
    {
        isRespawnTime = !isRespawnTime;
        if (isRespawnTime)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }
        else
        {
            spriteRenderer.color = new Color(1, 1, 1, 1);
        }
    }
    void Update()
    {
        Move();
        Fire();
        Boom();
        Reload();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isRight && h == 1) || (isLeft && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        if ((isTop && v == 1) || (isBottom && v == -1))
            v = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Vertical") || Input.GetButtonUp("Vertical"))
        {
            anim.SetInteger("Input", (int)v);
        }
    }

    void Fire()
    {
        if (!Input.GetButton("Fire1"))
            return;

        if (curShotDelay < maxShotDelay)
            return;
        
        switch (power)
        {
            case 1:
                GameObject bullet = objectManager.MakeObj("BulletPlayerA");
                bullet.transform.position = transform.position;

                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                break;
            case 2:
                GameObject bulletR = objectManager.MakeObj("BulletPlayerA");
                bulletR.transform.position = transform.position + Vector3.down * 0.1f;
                GameObject bulletL = objectManager.MakeObj("BulletPlayerA");
                bulletL.transform.position = transform.position + Vector3.up * 0.1f;

                Rigidbody2D rigidR = bulletR.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidL = bulletL.GetComponent<Rigidbody2D>();
                rigidR.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                rigidL.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                break;
            case 3:
                GameObject bulletR2 = objectManager.MakeObj("BulletPlayerA");
                bulletR2.transform.position = transform.position + Vector3.down * 0.35f;
                GameObject bulletL2 = objectManager.MakeObj("BulletPlayerA");
                bulletL2.transform.position = transform.position + Vector3.up * 0.35f;
                GameObject bulletc = objectManager.MakeObj("BulletPlayerB");
                bulletc.transform.position = transform.position;

                Rigidbody2D rigidR2 = bulletR2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidL2 = bulletL2.GetComponent<Rigidbody2D>();
                Rigidbody2D rigidc = bulletc.GetComponent<Rigidbody2D>();
                rigidR2.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                rigidL2.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                rigidc.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
                break;

        }
        

        curShotDelay = 0;
    }

    void Boom()
    {
        if (!Input.GetButton("Fire2"))
            return;

        if (isBoomTime)
            return;

        if (boom == 0)
            return;

        boom--;
        isBoomTime = true;
        gameManager.UpdateBoomIcon(boom);

        boomEffect.SetActive(true);
        Invoke("OffBoomEffect", 4f);

        GameObject[] enemiesL = objectManager.GetPool("EnemyL");
        GameObject[] enemiesM = objectManager.GetPool("EnemyM");
        GameObject[] enemiesS = objectManager.GetPool("EnemyS");
        GameObject[] boss = objectManager.GetPool("Boss");
        for (int idx = 0; idx < enemiesL.Length; idx++)
        {
            if (enemiesL[idx].activeSelf)
            {
                Enemy enemyLogic = enemiesL[idx].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }

        }
        for (int idx = 0; idx < enemiesM.Length; idx++)
        {
            if (enemiesM[idx].activeSelf)
            {
                Enemy enemyLogic = enemiesM[idx].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }

        }
        for (int idx = 0; idx < enemiesS.Length; idx++)
        {
            if (enemiesS[idx].activeSelf)
            {
                Enemy enemyLogic = enemiesS[idx].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }

        }
        for (int idx = 0; idx < boss.Length; idx++)
        {
            if (boss[idx].activeSelf)
            {
                Enemy enemyLogic = boss[idx].GetComponent<Enemy>();
                enemyLogic.OnHit(1000);
            }

        }

        GameObject[] bulletsA = objectManager.GetPool("BulletEnemyA");
        GameObject[] bulletsB = objectManager.GetPool("BulletEnemyB");
        GameObject[] bossbulletsA = objectManager.GetPool("BulletBossA");
        GameObject[] bossbulletsB = objectManager.GetPool("BulletBossB");
        for (int idx = 0; idx < bulletsA.Length; idx++)
        {
            if (bulletsA[idx].activeSelf)
            {
                bulletsA[idx].SetActive(false);
            }
        }
        for (int idx = 0; idx < bulletsB.Length; idx++)
        {
            if (bulletsB[idx].activeSelf)
            {
                bulletsB[idx].SetActive(false);
            }
        }
        for (int idx = 0; idx < bossbulletsA.Length; idx++)
        {
            if (bossbulletsA[idx].activeSelf)
            {
                bossbulletsA[idx].SetActive(false);
            }
        }
        for (int idx = 0; idx < bossbulletsB.Length; idx++)
        {
            if (bossbulletsB[idx].activeSelf)
            {
                bossbulletsB[idx].SetActive(false);
            }
        }
    }

    void Reload()
    {
        curShotDelay += Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {
            switch(collision.gameObject.name)
            {
                case "Top":
                    isTop = true;
                    break;
                case "Bottom":
                    isBottom = true;
                    break;
                case "Left":
                    isLeft = true;
                    break;
                case "Right":
                    isRight = true;
                    break;
            }
        }

        else if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            if (isRespawnTime)
                return;

            if (isHit)
                return;

            isHit = true;
            life--;
            gameManager.UpdateLifeIcon(life);
            gameManager.CallExplosion(transform.position, "Player");

            if (life == 0)
            {
                gameManager.GameOver();
            }
            else
            {
                gameManager.RespawnPlayer();
            }
            
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.tag == "Item")
        {
            Item item = collision.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Coin":
                    score += 1000;
                    break;
                case "Power":
                    if (power == maxPower)
                        score += 500;
                    else
                        power++;
                    break;
                case "Boom":
                    if (boom == maxBoom)
                        score += 500;
                    else
                    {
                        boom++;
                        gameManager.UpdateBoomIcon(boom);
                    }
                    break;
            }
            collision.gameObject.SetActive(false);
        }
    }

    void OffBoomEffect()
    {
        boomEffect.SetActive(false);
        isBoomTime = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    isTop = false;
                    break;
                case "Bottom":
                    isBottom = false;
                    break;
                case "Left":
                    isLeft = false;
                    break;
                case "Right":
                    isRight = false;
                    break;
            }
        }
    }
}
