﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EcoMundi.Data
{
    [CreateAssetMenu(fileName = "GameLocalDatabase", menuName = "EcoMundi/Databases/GameLocalDatabase", order = 50)]
    public class GameLocalDatabase : ScriptableObject
    {
        [Header("PROVINCES")]
        public List<ProvincePropsData> provinceDatabase;

        [Header("QUIZZES")]
        public List<QuizData> quizDatabase;
        private int _randomIndex;

        [Header("ECOFOOTPRINTS")]
        public List<EcoFootprint> ecoFootprintList;

        public int GetRandomQuizIndex(E_QuizType p_quizType)
        {
            do
            {
                _randomIndex = UnityEngine.Random.Range(0, quizDatabase.Count);
            }
            while (quizDatabase[_randomIndex].quizType != p_quizType);

            return _randomIndex;
        }

        #region [-----     METHODS     -----]

        public EcoFootprint GetZoneTypeInformation(E_ZoneType p_zoneType)
        {
            foreach (EcoFootprint ecoFootprint in ecoFootprintList)
            {
                if (ecoFootprint.zoneType == p_zoneType)
                    return ecoFootprint;
            }

            return null;
        }

        #endregion
    }

    #region [-----     PROVINCES     -----]

    [Serializable]
    public class ProvincePropsData
    {
        public E_Province province;
        public GameObject symbolPrefab;
        public string monumentName;
    }

    public enum E_Province
    {
        None,

        Galapagos,

        Esmeraldas,
        Manabi,
        SantaElena,
        LosRios,
        Guayas,
        ElOro,
        SantoDomingo,

        Pichincha,
        Tungurahua,
        Cotopaxi,
        Carchi,
        Chimborazo,
        Imbabura,
        Loja,
        Bolivar,
        Azuay,
        Cañar,

        Sucumbios,
        MoronaSantiago,
        Napo,
        ZamoraChinchipe,
        Orellana,
        Pastaza
    }

    #endregion

    #region [-----     QUIZ     -----]

    [Serializable]
    public class QuizData
    {
        [TextArea(2,4)]
        public string question;
        [Space]
        public E_QuizType quizType;
        [Space]
        public E_ZoneType affectedZoneOne;
        public E_ZoneType affectedZoneTwo;
        [Space]
        public List<AnswerData> answerOptions;
        [TextArea(2,4)]
        public string answerFeedback;
    }

    [Serializable]
    public class AnswerData
    {
        [TextArea(2,4)]
        public string answer;
        public bool isCorrect;
    }

    public enum E_QuizType
    {
        Home,
        Institute,
        Mall,
        General,
        Transport
    }

    #endregion

    #region [-----     ECO FOOTPRINTS     -----]

    [System.Serializable]
    public class EcoFootprint
    {
        public E_ZoneType zoneType;
        public string zoneName;
        public Sprite zoneSprite;
    }

    #endregion

}
