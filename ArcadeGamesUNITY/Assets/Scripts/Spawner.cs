using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // how often the enemies are spawned
    public float m_spawnTime;
    // each object to spawn
    public GameObject m_enemy;
    public GameObject m_civillian;
    public GameObject m_thrower;
    // the radius where the enemies can be spawned
    private float m_spawnRadius = 6;
    void Start()
    {      
        // starts the spawn fucntion and spawn coroutine on start
        F_spawnEnemy();
        StartCoroutine("I_spawnerEnemies");       
    }
    // looping sequence of spawning the NPCs
    IEnumerator I_spawnerEnemies()
    {
        yield return new WaitForSeconds(m_spawnTime);
        F_spawnEnemy();
        StartCoroutine("I_spawnerEnemies");

    }

    private  void F_spawnEnemy()
    {
        // uses a for loop to spawn multiple NPCs each cycle
        for (int i = 1; i < 3; i++)
        {
            // each enemy has an integer variable and the enemy type is randomly chosen each loop.
            int m_enemytype = Random.Range(1, 6);
                    
            if( m_enemytype == 2)
            {
                // spawns the enemy in a given radius using a random vector. 
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_civillian, (transform.position + m_randomVector), Quaternion.identity);
            }
            if (m_enemytype == 3)
            {
                // spawns the enemy in a given radius using a random vector. 
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_thrower, (transform.position + m_randomVector), Quaternion.identity);
            }
            else
            {
                // spawns the enemy in a given radius using a random vector. 
                Vector3 m_randomVector = new Vector3(Random.Range(-m_spawnRadius, m_spawnRadius), 0, Random.Range(-m_spawnRadius, m_spawnRadius));
                Instantiate(m_enemy, (transform.position + m_randomVector), Quaternion.identity);
            }


        }
    }

    
    
   
    
}
