using System;
using System.Collections.Generic;

public class WaveSequence
{
    public List<WaveData> SequenceWave = new List<WaveData>();

	public WaveSequence()
	{
        //The First Add it's only the first WaveData
        //The rest change every 5 waves (See SpaceRoaches → line 130)

        SequenceWave.Add(
            new WaveData(
                //Weights (Roach, SpikeBall, Pizza)
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 0, 0),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new WaveData(
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 1, 1),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new WaveData(
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 2, 1),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new WaveData(
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 2, 1),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new WaveData(
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 3, 1),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new WaveData(
                AddWeights(75, 23, 4),
                AddMinPerWave(6, 0, 0),
                AddMaxPerWave(8, 4, 1),
                AddLimits(15, 5, 1)
            )
        );
    }

    private int[] AddWeights(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }

    private int[] AddMinPerWave(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }

    private int[] AddMaxPerWave(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }

    private int[] AddLimits(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }
}
