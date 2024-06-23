using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyTestManager : MonoBehaviour
    {

        [SerializeField] GameObject player;

        List<Enemy> enemies = new List<Enemy>();
        void Start()   
        {
            InitList(enemies);
            
        }

        private void InitList(List<Enemy> enemies)
        {
            GameObject[] temp = GameObject.FindGameObjectsWithTag("Enemy");
            for(int i = 0; i < temp.Length; i++)
            {
                enemies.Add(temp[i].GetComponent<Enemy>());
            }
        }

        void PlayTurn()
        {
            foreach(Enemy enemy in enemies)
            {
                enemy.PlayTurnAction(enemy.transform.position.x - player.transform.position.x);
            }
        }

        void Update()
        {
           if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTurn();
            }
        }
    }
}


