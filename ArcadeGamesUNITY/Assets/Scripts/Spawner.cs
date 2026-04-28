using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float m_spawnTime;
    
    public GameObject m_enemy;
    public GameObject m_civillian;
    void Start()
    {
        
        m_spawnTime = 15f;
        F_spawnEnemy();
        StartCoroutine("F_spawnerEnemies");
        StartCoroutine("F_spawnerCIV");

    }
    IEnumerator F_spawnerEnemies()
    {
        yield return new WaitForSeconds(15);
        F_spawnEnemy();
        StartCoroutine("F_spawnerEnemies");

    }

    private  void F_spawnEnemy()
    {
        for (int i = 1; i < 10; i++)
        {
            Debug.Log("Spawn");
            Vector3 m_randomVector = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            Instantiate(m_enemy, (transform.position + m_randomVector), Quaternion.identity);

        }
    }

    IEnumerator F_spawnerCIV()
    {
        yield return new WaitForSeconds(10);
        F_spawnCIV();
        StartCoroutine("F_spawnerCIV");
    }

    private void F_spawnCIV()
    {
        Vector3 m_randomVector = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
        Instantiate(m_civillian, (transform.position + m_randomVector), Quaternion.identity);
    }
    
   
    
}
