using System;
using System.Collections.Generic;

public class WaveSequence
{
    public List<Wave> SequenceWave = new List<Wave>();

	public WaveSequence()
	{
        //The First Add it's only the first Wave
        //The rest change every 5 waves (See SpaceRoaches → line 130)

        SequenceWave.Add(
            new Wave(
                //Weights (Roach, SpikeBall, Pizza)
                AddWeights(75, 23, 2),
                //Ranges In Wave (Roach {min, max}, SpikeBall {min, max}, Pizza {min, max})
                AddRanges(new int[] { 6, 8 }, new int[] { 0, 0 }, new int[] { 0, 0 }),
                //Limits In Scene (Roach, SpikeBall, Pizza)
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new Wave(
                AddWeights(75, 23, 2),
                AddRanges(new int[] { 6, 8 }, new int[] { 0, 1 }, new int[] { 0, 1 }),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new Wave(
                AddWeights(75, 23, 2),
                AddRanges(new int[] { 6, 8 }, new int[] { 0, 2 }, new int[] { 0, 1 }),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new Wave(
                AddWeights(75, 23, 2),
                AddRanges(new int[] { 8, 10 }, new int[] { 0, 2 }, new int[] { 0, 1 }),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new Wave(
                AddWeights(75, 23, 2),
                AddRanges(new int[] { 8, 10 }, new int[] { 0, 3 }, new int[] { 0, 1 }),
                AddLimits(15, 5, 1)
            )
        );
        SequenceWave.Add(
            new Wave(
                AddWeights(75, 23, 2),
                AddRanges(new int[] { 8, 10 }, new int[] { 0, 4 }, new int[] { 0, 1 }),
                AddLimits(15, 5, 1)
            )
        );
    }

    private int[] AddWeights(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }

    private List<int[]> AddRanges(int[] roach, int[] spikeBall, int[] pizza)
    {
        List<int[]> rangesList = new List<int[]>();
        rangesList.Add(roach);
        rangesList.Add(spikeBall);
        rangesList.Add(pizza);
        return rangesList;
    }

    private int[] AddLimits(int roach, int spikeBall, int pizza)
    {
        return new int[] { roach, spikeBall, pizza };
    }
}
