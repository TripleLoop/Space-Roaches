using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

///TODO: use json instead static class for configuration
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
            public const float ZPosition = -15;
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
            //Percent of intensity reduction when break (0 = nothing / 1 = all)
            public const float BreakDashIntensity = 0.8f;
            public const float TimeToBreak = 0.5f;
            public const float TimeBreak = 0.1f;
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

    public static class DashMeter
    {
        public const float TimeLoadBar = 0.025f;
        public const float SizeUpLoadBar = 0.0025f;
        public const float SizeDownDownloadBar = 0.15f;
    }

    public static class EndScreen
    {
        public const float TimeCountUp = 0.05f;

        ///TODO: pull all texts into files and loaded them, use json
        private static class Texts
        {
            //Comments showed on EndScreen depending of score
            //Score = 0
            public static readonly string[] FirstRange = {
                "You’re an ungerminated seed.",
                "Seems like you've not started on the right foot.",
                "Next time it will SURELY go better.",
                "Neither sound or your score can be transmitted in space.",
                "Nope, spikeballs are not good.",
                "Gravity here is null. So is your score.",
                "NOPE.",
                "Nothing dies faster than an idea in a closed mind. Except you."
            };
            //Score = 1 → 20
            public static readonly string[] SecondRange =
            {
                "If you were an astronaut, your spaceship would be a water rocket.",
                "Tell your grandma to give back your phone.",
                "Small tip: open your eyes while you play.",
                "Let’s pretend this didn't happen.",
                "If gravity was based on your score, we’d all be flying.",
                "Start planting potatoes and pray to be rescued.",
                "Warning: this game’s not suitable for limbless persons.",
                "You can do a lot better, and a very little worse."

            };
            //Score = 21 → 40
            public static readonly string[] ThirdRange =
            {
                "Well, it could have been worse.",
                "Everything starts with something.",
                "Sorry, your suit is not spikeproof.",
                "Houston, we’ve got a problem.",
                "Houston says you’re the problem.",
                "What was that?",
                "IT’S A TRAP!",
                "Life in space isn’t easy, is it?"
            };
            //Score = 41 → 60
            public static readonly string[] FourthRange =
            {
                "You looked just like a shooting star, but you’ve disintegrated.",
                "Seems like you’re starting to take off.",
                "Not bad.",
                "Maybe you’re not THAT bad.",
                "You’re doing better everytime!",
                "Stars are starting to shine.",
                "You can smell the scent of fear coming from the roaches.",
                "Practise is everything."
            };
            //Score = 61 → 80
            public static readonly string[] FifthRange =
            {
                "The universe is on your side.",
                "The force is inside you.",
                "You’re pretty good at floating around!",
                "You’re like an insecticide made of human flesh.",
                "One little step for a man, one giant leap for manking.",
                "The sun comes up, and it shines all around you.",
                "You’re a space cowboy."
            };
            //Score = 81 → 100
            public static readonly string[] SixthRange =
            {
                "You got out from earth to become a star.",
                "There are 3 infinite things: the universe, human stupidity and your score.",
                "Your score has entered into a supernova.",
                "Left as a weirdo. Returned as a legend.",
                "Your score is stratospheric.",
                "Next stop, the limits of the universe.",
                "Your power level is OVER NINE THOUSAAAAND!"
            };
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

    public static class MainMenu
    {
        public static class Environment
        {
            public static class Astronaut
            {
                public const float PushForce = 0.5f;
                public const float TorqueForce = 0.1f;
                public const float MinTimeBetweenExit = 0;
                public const float MaxTimeBetweenExit = 7f;
            }

            public static SideThrower[] Sides = new SideThrower[2]
            {
               //top side
               //new SideThrower(UpperLeftLimit,UpperRightLimit,new Vector2(0, 0),1f),
               //left side
               new SideThrower(LowerLeftLimit,UpperLeftLimit,new Vector2(0, 0),1f),
               //lower side
               //new SideThrower(LowerRightLimit,LowerLeftLimit,new Vector2(0, 0),1f),
               //right side
               new SideThrower(UpperRightLimit,LowerRightLimit,new Vector2(0, 0),1f),
            };

            public static Vector2 UpperLeftLimit
            {
                get { return new Vector2(-5, 3); }
            }

            public static Vector2 UpperRightLimit
            {
                get { return new Vector2(5, 3); }
            }

            public static Vector2 LowerLeftLimit
            {
                get { return new Vector2(-5, -3); }
            }

            public static Vector2 LowerRightLimit
            {
                get { return new Vector2(5, -3); }
            }

        }
    }

    public static class TypeWritting
    {
        public const float TimePerLetter = 0.03f;
    }



}

