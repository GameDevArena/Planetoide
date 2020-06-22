﻿using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EcoMundi.Managers
{
    public class LoginSceneManager : MonoBehaviour
    {
        [Header("Game Services")]
        public TMP_Text authStatusLabel;
        public TMP_Text signInButtonLabel;



        private void Start()
        {
            // <START> GooglePlayGames init
            PlayGamesClientConfiguration playGamesConfig = new PlayGamesClientConfiguration.Builder().Build();
            // Enable DEBUG output
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.InitializeInstance(playGamesConfig);
            PlayGamesPlatform.Activate();
            // Trying silent sign-in
            Social.Active.localUser.Authenticate(SignInCallback);

            // </END>


        }

        #region [-----     PLAY GAMES SERVICES     -----]

        public void SignInToPlayServicesButton()
        {
            if (!Social.Active.localUser.authenticated)
            {
                Social.Active.localUser.Authenticate(SignInCallback);
            }
            else
            {
                PlayGamesPlatform.Instance.SignOut();

                signInButtonLabel.text = "Sign in";
                authStatusLabel.text = "";
            }
        }


        private void SignInCallback(bool p_success)
        {
            if (p_success)
            {
                Debug.Log($"[GameServices] Signed in !");

                signInButtonLabel.text = "Sign out";
                authStatusLabel.text = $"Signed in as: {Social.Active.localUser.userName}";
            }
            else
            {
                Debug.Log($"[GameServices] Sign-in failed...");

                signInButtonLabel.text = "Sign in";
                authStatusLabel.text = $"Sign-in failed...";
            }
        }

        #endregion

        public void GoToGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}