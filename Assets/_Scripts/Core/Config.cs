public static class Config
{
    //ENTITIES
    //Intensity Astronaut Dash
    public const float dashIntensity = 4f;
    //Percent of intesity kept when break (0 = all / 1 = all)
    public const float breakDashIntensity = 0.9f;
    //Velocity when idle State
    public const float minVelocity = 2f;

    //Intensity when is spawned
    public const float spikeBallForceStrenght = 50f;
    public const float pizzaForceStrenght = 75f;

    //Range of start direction
    public const float minAngleDirection = 90;
    public const float maxAngleDirection = 271;


    //SPAWN CONDITIONS
    //Limit of elements in game
    public const float minSpawnElements = 5;
    public const float maxSpawnElements = 16;

    //Max distance of creation element
    public const float maxRadius = 0.45f;
    //Number of tries before reduce radius
    public const float maxTries = 15;

    //Spawn limit of each entity
    public const float roachMaxCount = 15;
    public const float spikeBallMaxCount = 4;
    public const float pizzaMaxCount = 1;

    //Weights of each entity (Probability to spawn)
    public const float roachWeight = 75;
    public const float spikeBallWeight = 23;
    public const float pizzaWeight = 2;

    //Cooldown to spawn another pizza after despawn
    public const float pizzaCooldown = 30f;


    //SYSTEM
    //z position of Camera
    public const float zPositionCamera = 15;
    //Shake of camera
    public const float shakeDuration = 0.5f;
    public const float shakeMagnitude = 0.1f;
    //Camera damp
    public const float cameraDampTime = 0.2f;

    //Score checkpoints to speed up the game
    public static readonly int[] speedMarks = {15, 40, 100, 250, 600};
    //Max speed game
    public const float maxTimeScale = 3;
    public const float addedTimeScale = 0.3f;

    //Time for next incoming wave
    public const float secondsNextWave = 10;
    //Time for next incoming wave if all enemies are despawned
    public const float secondsFastWave = 3;
}
