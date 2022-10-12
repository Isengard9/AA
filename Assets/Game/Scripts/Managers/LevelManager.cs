using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTemplateProjects.Systems;

namespace UnityTemplateProjects.Managers
{
    public class LevelManager : MonoBehaviour
    {
        public List<LevelSystem> levels = new List<LevelSystem>();
        
        private void Start()
        {
            int index = PlayerPrefs.GetInt("LevelId", 0);
            BigBallController.instance.SetLevel(levels[index].BigBallModifiers);
            SmallBallManager.instance.SetSmallBallCount(levels[index].smallBallCount);
        }
    }
}