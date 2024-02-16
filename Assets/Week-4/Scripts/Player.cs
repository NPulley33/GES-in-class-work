using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Week4 
{
    public class Player : MonoBehaviour
    {
        //public int health { get { return _health} private set { _health = value; } }
        //private int _health = 10;


        //public int health { get; private set; }
        //private void Awake()
        //{
        //    health = 10;
        //}

        [SerializeField]
        private int health = 10;
        public int GetHealth() {
            return health;
        }

        public Enemy FindNewEnemy() {
            //Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
            //int randomIndex = Random.Range(0, enemies.Length);
            //return enemies[randomIndex];

            //GameObject.FindGameObjectWithTag("Enemy"); //objects version also

            GameObject enemyObj = GameObject.Find("Enemy");
            Enemy enemyComp = enemyObj.GetComponent<Enemy>();
            return enemyComp;
        }

        [ContextMenu("Attack")]
        void Attack() { 
            Enemy target = FindNewEnemy();
            target.Damage(5);
        }

        public void Damage(int amount) { 
            health -= amount;
        }

    }
}
