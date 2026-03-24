using System.Collections;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float resetTime = 3f;
    private SpriteRenderer sr;
    private Collider2D col;



    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void F_Hit()
    {
        Debug.Log("F_Hit Called!!!");
        col.enabled = false;
        sr.enabled = false;
        StartCoroutine (CR_Reset());
    }

    private IEnumerator CR_Reset()
    {
        yield return new WaitForSeconds(resetTime);
        sr.enabled = true;
        col.enabled = true;
    }

}
