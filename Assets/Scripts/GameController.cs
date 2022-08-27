using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    [SerializeField] private int score = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int levelBase = 100;

    private float waitEnemies = 0f;
    [SerializeField] private float timeWait = 5f;

    [SerializeField] private int qtdEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyGenerate();
    }

    public void GetScore(int score)
    {
        this.score += score;

        if(this.score > levelBase * level)
        {
            level++;
        }
    }

    public void DiminuiQuantidade()
    {
        qtdEnemies--;
    }


    private void EnemyGenerate()
    {

        if(waitEnemies > 0f && qtdEnemies <=0)
        {
            waitEnemies -= Time.deltaTime;
        }

        if(waitEnemies <= 0f)
        {

            int quantidade = level * 2;

            while (qtdEnemies < quantidade)
            {

                GameObject createdEnemy;

                float chance = Random.Range(0f, level);
                if (chance > 2f)
                {
                    createdEnemy = enemies[1];
                }
                else
                {
                    createdEnemy = enemies[0];
                }

                Vector3 position = new Vector3(Random.Range(-8f, 8f), Random.Range(6f, 17f), 0f);
                Instantiate(createdEnemy, position, transform.rotation);
                qtdEnemies++;

                waitEnemies = timeWait;
            }
        }
    }

}
