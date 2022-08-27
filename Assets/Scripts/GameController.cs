using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;

    private int score = 0;
    [SerializeField] private int level = 1;

    private float waitEnemies = 0f;
    [SerializeField] private float timeWait = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyGenerate();
    }

    private void EnemyGenerate()
    {

        if(waitEnemies > 0f)
        {
            waitEnemies -= Time.deltaTime;
        }

        if(waitEnemies <= 0f)
        {

            int quantidade = level * 2;
            int qtdEnemies = 0;

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
                Debug.Log(position.y);

                waitEnemies = timeWait;
            }
        }
    }

}
