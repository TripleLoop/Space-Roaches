using System;
using System.Collections.Generic;

public class WaveData
{
    //Spawn (%)
    public int[] SpawnWeights;
    //Min per Round
    public int[] MinPerWave;
    //Max per Round
    public int[] MaxPerWave;
    //Limit in Scene
    public int[] LimitsInScene;

    public WaveData(int[] spawnWeights , int[] minPerWave, int[] maxPerWave, int[] limitsInScene)
    {
        SpawnWeights = spawnWeights;
        MinPerWave = minPerWave;
        MaxPerWave = maxPerWave;
        LimitsInScene = limitsInScene;
    }
    
}
