using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float m_spawnTime;
    
    public GameObject m_enemy;
    public GameObject m_civillian;
    public GameObject m_thrower;
    private float m_spawnRadius = 6;
    void Start()
    {
        
        
        F_spawnEnemy();
        StartCoroutine("F_spawnerEnemies");
        StartCoroutine("F_spawnerCIV");

    }
    IEnumerator F_spawnerEnemies()
    {
        yield return new WaitForSeconds(m_spawnTime);
        F_spawnEnemy();
        StartCoroutine("F_spawnerEnemies");

    }

    private  void F_spawnEnemy()
    {
        for (int i = 1; i < 3; i++)
        {
            int m_enemytype = Random.Range(1, 6);
             
            
            if( m_enemytype == 2)
            {
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_civillian, (transform.position + m_randomVector), Quaternion.identity);
            }
            if (m_enemytype == 3)
            {
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_thrower, (transform.position + m_randomVector), Quaternion.identity);
            }
            else
            {
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_enemy, (transform.position + m_randomVector), Quaternion.identity);
            }


        }
    }

    
    
   
    
}
