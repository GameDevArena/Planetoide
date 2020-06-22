﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EcoMundi.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public delegate void FakeUpdate();
        public static event FakeUpdate OnFakeUpdate;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            SceneManager.LoadScene("LoginScene");
        }

        private void Update()
        {
            if (OnFakeUpdate != null)
                OnFakeUpdate.Invoke();
        }

    }
}
