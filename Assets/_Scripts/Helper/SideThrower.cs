using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class SideThrower
{

    private readonly Vector2 _sideOrigin;
    private readonly Vector2 _sideEnd;
    private readonly Vector2 _directionOrigin;
    private readonly float _directionVariance;

    public SideThrower(Vector2 sideOrigin, Vector2 sideEnd, Vector2 directionOrigin, float directionVariance)
    {
        _sideOrigin = sideOrigin;
        _sideEnd = sideEnd;
        _directionOrigin = directionOrigin;
        _directionVariance = directionVariance;
    }

    public Vector2 RandomPosition()
    {
        return RandomBetweenPositions(_sideOrigin, _sideEnd); 
    }

    public Vector2 RandomDirection(Vector2 origin)
    {
        float varianceX = Random.Range(-_directionVariance, _directionVariance);
        float varianceY = Random.Range(-_directionVariance, _directionVariance);
        Vector2 directionPosition = new Vector2(_directionOrigin.x + varianceX, _directionOrigin.y + varianceY);
        Vector2 direction = directionPosition - origin;
        return direction.normalized;
    }

    private Vector2 RandomBetweenPositions(Vector2 position1, Vector2 position2)
    {
        float randomX = Random.Range(position1.x, position2.x);
        float randomY = Random.Range(position1.y, position2.y);
        return new Vector2(randomX, randomY);
    }
}
