using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float m_spawnTime;
    
    public GameObject m_enemy;
    void Start()
    {
        
        m_spawnTime = 15f;
        f_spawnEnemy();
        StartCoroutine("F_spawner");
     

    }
    IEnumerator F_spawner()
    {
        
        
       
        yield return new WaitForSeconds(m_spawnTime);
        f_spawnEnemy();
        Debug.Log("Enemy!!!");



        StartCoroutine("F_spawner");

    }

    private  void f_spawnEnemy()
    {
        for (int i = 1; i < 10; i++)
        {
            Debug.Log("Spawn");
            Vector3 m_randomVector = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20));
            Instantiate(m_enemy, (transform.position + m_randomVector), Quaternion.identity);

        }
    }
    
   
    
}
