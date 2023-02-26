using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameMetaData
{
    public string nextLevel;

    [Serializable]
    public struct LevelCellsData
    {
        public string levelSceneName;
        public bool levelLocked;

        public Sprite levelArtifactSprite;
        public bool artifactLocked;
    }

    public List<LevelCellsData> levels;

    public GameMetaData(string initialLevel)
	{
        nextLevel = initialLevel;

    }
}
