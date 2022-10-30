using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    ScoreManager ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(other.GetComponent<Enemy>())
        {
            Enemy enemy = (Enemy)other.GetComponent<Enemy>();
            ScoreText.UpdateHighScore(enemy.Points);

            Destroy(other.gameObject);
        }
    }
}
