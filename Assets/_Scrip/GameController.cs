using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace _Scrip
{
    public class GameController : MonoBehaviour
    {
        public static GameController instance;
        public float xMinMax;
        public float zMin;
        public GameObject enemy;
        public int count;
        public float startwait;
        public float waveWait;

        public float cloneWait;
        
        /*-------UI Text ---------------*/
        public GameObject gameOverOOO;
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI restartText;
        public int _score = 0;
        private bool _gameover;
        public bool _restart;
        
        public TextMeshProUGUI currentScore;
        public TextMeshProUGUI highScore;

       //private HighScore _highScore;
        
        private void Start()
        {
            _score = 0;
            scoreText.text = "Score: 0";
            gameOverOOO.gameObject.SetActive(false);
            restartText.gameObject.SetActive(true); 
            StartCoroutine(Waves());
            highScore.text = PlayerPrefs.GetInt("highscore").ToString();
           
           
        }
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            //_highScore = GetComponent<HighScore>();


        } 

        private void Update()
        {
            
        }


        IEnumerator Waves()
        {
            while (true)
            {
                yield return new WaitForSeconds(startwait);
                for (int i = 0; i < count; i++)
                {
                   // Instantiate(enemy, new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin), Quaternion.identity);
                   
                   enemy = ObjectPool.instance.GetEnemyPooledObject();
                   if (enemy != null)
                   {
                       enemy.transform.position = new Vector3(Random.Range(-xMinMax, xMinMax), 0, zMin);
                       enemy.SetActive(true);
                   }
                   yield return new WaitForSeconds(cloneWait);
                }

                if (_gameover)
                {
                    _restart = true;
                    restartText.text = "Press R to Restart ";
                    break;
                }
                yield return new WaitForSeconds(waveWait);
            }
      
        }

        public void AddScore(int score)
        {
            _score += score;
            scoreText.text = "Score: " + _score;
        } 

        public void GameOver()
        {
            gameOverOOO.gameObject.SetActive(true);
            //_highScore.UpdateHighscore();
            currentScore.text = _score.ToString();
            if (_score > PlayerPrefs.GetInt("highscore"))
            {
               
                PlayerPrefs.SetInt("highscore",_score);
                highScore.text =_score.ToString();
            }
        }

        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
            
        }
        
        
     
    }
}
