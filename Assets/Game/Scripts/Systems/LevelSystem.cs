using System.Collections.Generic;
using UnityEngine;

namespace UnityTemplateProjects.Systems
{
    [CreateAssetMenu(fileName = "Level", menuName = "Game/Level", order = 1)]
   
    public class LevelSystem : ScriptableObject
    {
        public List<BigBallRotationModifier> BigBallModifiers = new List<BigBallRotationModifier>();
        public int smallBallCount;
        public int connectedSmallBallCount;

    }
}