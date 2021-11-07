using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Core;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    Debug.LogError("Game Manager is Null!!!");
                }

                return instance;
            }
        }

        private void Awake()
        {
            instance = this;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(ScenesName.MainMenu);
            }
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene(ScenesName.Game);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadScene(ScenesName.MainMenu);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}