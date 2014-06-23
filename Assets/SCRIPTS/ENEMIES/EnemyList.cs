using UnityEngine;
using System.Collections;

public class EnemyList : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject getEnemy(string enemyCode)
    {
        GameObject enemy = null;
        switch (enemyCode)
        {
            case "E001":
                enemy = enemy1;
                break;
            case "E002":
                enemy = enemy2;
                break;
            case "E003":
                enemy = enemy3;
                break;
            case "E004":
                enemy = enemy4;
                break;
        }

        return enemy;
    }
}
