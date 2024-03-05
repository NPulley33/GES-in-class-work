using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        [SerializeField] private int health = 10;

//#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
//        private AudioSource audio;
//#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

        private void Awake()
        {
            //audio = GetComponent<AudioSource>();
        }

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
            Vector3 origin = transform.position;

            transform.DOMove(target.transform.position, 0.5f).OnComplete( () => { 
                target.Damage(5);
                transform.DOMove(origin, 0.5f);
            } ); 
            //lambda- dynamically writing a method while code is running

            //audio.clip = attackSound;
            //audio.PlayOneShot(attackSound);
            //AudioManager.PlaySound(AudioManager.SoundType.ATTACK); //putting 0 in works too, but don't
        }

        public void Damage(int amount) { 
            health -= amount;
        }


    }
}
