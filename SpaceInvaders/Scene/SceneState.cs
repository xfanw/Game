﻿
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SceneState
    {
        public float TimeAtPause;
        public virtual void Handle() { }
        public abstract void Initialize();
        public abstract void Update(float systemTime);
        public abstract void Draw();
        public abstract void Entering();
        public abstract void Leaving();

    }
}
