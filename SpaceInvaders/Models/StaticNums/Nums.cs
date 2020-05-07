using System;

namespace SpaceInvaders
{
    public class Nums
    {
        //level factor
        public static int Level = 1;
        public static float LevelUp = 1 + Level * 0.2f;

        // Alien Numbers
        public static int AlienNum = 55;

        // Aliens speed control:
        public static float AlienDeltaX = 2 * LevelUp;
        public static float AlienDeltaY = -15;
        public static float TimeUp = 10 / LevelUp;
        public static float SoundInterval = 0.5f / LevelUp; 

        //Bullet speed Control:
        public static readonly float BombSpeed = 2;
        public static readonly float ShipBulletSpeed = 5;

        //Ship Moving Speed:
        public static readonly float ShipSpeed = 5;
        public static int ShipLife = 3;

        //UFO speed:
        public static readonly float UFOSpeed = 2;

        // Score system
        public static readonly int SquidScore = 30;
        public static readonly int CrabScore = 20;
        public static readonly int OctopusScore = 10;




    }
}
