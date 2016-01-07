using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public static class Config
{
    public static class SpaceRoaches
    {
        //Score checkpoints to speed up the game
        public static readonly int[] SpeedMarks = { 15, 40, 100, 250, 600 };
        //max speed in the game
        public const float MaxTimeScale = 3f;
        //time added in each checkpoint
        public const float AddedTimeScale = 0.3f;
        public const float TimeBeforeFirstWave = 3f;
        public const int SecondsBetweenWaves = 10;
        public const int SecondsBetweenFastWaves = 3;
    }

    public static class BackendProxy
    {
        public static class Transaction
        {
            public const int NonStarted = 0;
            public const int InProcess = 1;
            public const int Succeeded = 2;
            public const int Failed = 3;
        }
    }

    public static class Camera
    {
        public static class Game
        {
            //public const float ZPosition = 15;
            public const float ShakeDuration = 0.25f;
            public const float ShakeMagnitude = 0.1f;
            public const float DampTime = 0.2f;
        }

    }

    public static class Entities
    {
        public static class Astronaut
        {
            //Intensity Astronaut Dash
            public const float DashIntensity = 6f;
            //Percent of intensity when break (0 = nothing / 1 = all)
            public const float BreakDashIntensity = 0.8f;
            //Velocity when idle State
            public const float MinVelocity = 2f;
            public const float ImmortalityTime = 8.0f;
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

    public static class Audio
    {
        //Ask before changing this
        public static class MusicSlider
        {
            public const float MaxValue = 20f;
            public const float MinValue = -20f;
        }

        //Ask before changing this
        public static class EffectsSlider
        {
            public const float MaxValue = 20f;
            public const float MinValue = -20f;
        }
    }

    public static class WaveManager //spawn conditions
    {
        public static class Wave
        {
            public const int MaxElements = 5;
            public const int MinElements = 16;
            //inital limit area between elements
            public const float InitialRadius = 0.45f;
            //tries before reducing the radius
            public const int MaxTries = 15;
        }

        public static class SpawnArea
        {
            public static readonly Vector2 OriginPosition = new Vector2(-6.07f, 3.26f);
            public static readonly Vector2 EndPosition = new Vector2(5.81f, -3.12f);
        }

        public static class Roach
        {
            public const int Weight = 75;
            public const int MaxCount = 15;
        }

        public static class SpikeBall
        {
            public const int Weight = 23;
            public const int MaxCount = 4;
        }

        public static class Pizza
        {
            public const int Weight = 2;
            public const int MaxCount = 1;
            public const float Cooldown = 30f;
        }
    }

    public static class EndScreen
    {
        private static class Texts
        {
            //Comments showed on EndScreen depending of score
            //Score = 0
            public static readonly string[] FirstRange = {"one", "two", "three"};
            //Score = 1 → 20
            public static readonly string[] SecondRange = {"one", "two", "Not bad for a limbless person"};
            //Score = 21 → 40
            public static readonly string[] ThirdRange = {"one", "two", "three"};
            //Score = 41 → 60
            public static readonly string[] FourthRange = {"one", "two", "three"};
            //Score = 61 → 80
            public static readonly string[] FifthRange = { "one", "two", "three" };
            //Score = 81 → 100
            public static readonly string[] SixthRange = { "one", "two", "three" };
        }

        
        public static List<RangeComments> AllRangesComments = new List<RangeComments>()
        {
            //The minimum and maximum values are inclusives
            new RangeComments(Texts.FirstRange, 0, 0),
            new RangeComments(Texts.SecondRange, 1, 20),
            new RangeComments(Texts.ThirdRange, 21, 40),
            new RangeComments(Texts.FourthRange, 41, 60),
            new RangeComments(Texts.FifthRange, 61, 80),
            new RangeComments(Texts.SixthRange, 81, 100)
        };
    }


}

