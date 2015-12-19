public static class Config
{
    public static class Entities
    {
        public static class Astronaut
        {
            //Intensity Astronaut Dash
            public const float DashIntensity = 6f;
            //Percent of intensity when break (0 = all / 1 = all)
            public const float BreakDashIntensity = 0.8f;
            //Velocity when idle State
            public const float MinVelocity = 2f;
        }

        public static class Spikeball
        {
            public const float PushForce = 50f;
            public const float MinDirectionX = -1f;
            public const float MaxDirectionX = 1f;
            public const float MinDirectionY = -1f;
            public const float MaxDirectionY = 1f;
        }

        public static class Pizza
        {
            public const float PushForce = 75f;
            public const float MinDirectionX = -1f;
            public const float MaxDirectionX = 1f;
            public const float MinDirectionY = -1f;
            public const float MaxDirectionY = 1f;
        }
    }

    ////SPAWN CONDITIONS
    ////Limit of elements in game
    //public const float minSpawnElements = 5;
    //public const float maxSpawnElements = 16;

    ////Max distance of creation element
    //public const float maxRadius = 0.45f;
    ////Number of tries before reduce radius
    //public const float maxTries = 15;

    ////Spawn limit of each entity
    //public const float roachMaxCount = 15;
    //public const float spikeBallMaxCount = 4;
    //public const float pizzaMaxCount = 1;

    ////Weights of each entity (Probability to spawn)
    //public const float roachWeight = 75;
    //public const float spikeBallWeight = 23;
    //public const float pizzaWeight = 2;

    ////Cooldown to spawn another pizza after despawn
    //public const float pizzaCooldown = 30f;


    ////SYSTEM
    ////z position of Camera
    //public const float zPositionCamera = 15;
    ////Shake of camera
    //public const float shakeDuration = 0.5f;
    //public const float shakeMagnitude = 0.1f;
    ////Camera damp
    //public const float cameraDampTime = 0.2f;

    ////Score checkpoints to speed up the game
    //public static readonly int[] speedMarks = { 15, 40, 100, 250, 600 };
    ////Max speed game
    //public const float maxTimeScale = 3;
    //public const float addedTimeScale = 0.3f;

    ////Time for next incoming wave
    //public const float secondsNextWave = 10;
    ////Time for next incoming wave if all enemies are despawned
    //public const float secondsFastWave = 3;
}
