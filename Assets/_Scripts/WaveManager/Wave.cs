using System;
using System.Collections.Generic;

public class Wave
{
    //Spawn (%)
    public int[] SpawnWeights;
    //Range per Round
    public List<int[]> RangesPerWave;
    //Limit in Scene
    public int[] LimitsInScene;

    public Wave(int[] spawnWeights , List<int[]> rangesPerWave, int[] limitsInScene)
    {
        SpawnWeights = spawnWeights;
        RangesPerWave = rangesPerWave;
        LimitsInScene = limitsInScene;
    }
    
}
