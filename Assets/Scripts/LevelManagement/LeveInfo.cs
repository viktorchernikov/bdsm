﻿using System;
using AccountManagement;

namespace LevelManagement
{
    public class LevelInfo
    {
        private readonly LevelDefinition _definition;
        private readonly LevelStatistics _statistics;
        private LevelStatus _status;
    
        public readonly int LevelID;
        public string LevelName => _definition.SceneName;

        public LevelStatus Status
        {
            get => _status;
            set
            {
                _statistics.isPassed = value == LevelStatus.Passed;

                _status = value;
            }
        }
    
        private readonly LevelInfo[] _lastLevels;

        public LevelInfo[] LastLevels => _lastLevels.Clone() as LevelInfo[];

        public LevelInfo(LevelStatus status, LevelDefinition definition, LevelStatistics statistics = null)
        {
            if (definition == null) throw new Exception("Level definition is null");
            if (statistics is not null && statistics.levelID != definition.LevelID) throw new Exception("LevelID doesn't match");

            LevelID = definition.LevelID;
            Status = status;
            _definition = definition;
            _statistics = statistics != null ? statistics.Clone() as LevelStatistics : new LevelStatistics();
        }

        public LevelStatistics GetLevelStatistics()
        {
            return _statistics.Clone() as LevelStatistics;
        }
    }
}

