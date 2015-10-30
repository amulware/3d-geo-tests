﻿using amulware.Graphics;
using Bearded.Utilities.Collections;
using Bearded.Utilities.SpaceTime;
using OpenTK;

namespace Game
{
    sealed class GameState
    {
        private readonly DeletableObjectList<GameObject> gameObjects = new DeletableObjectList<GameObject>();
        private Instant time = Instant.Zero;

        public Instant Time { get { return this.time; } }

        public GameState()
        {
            for (int x = 0; x < 10; x++)
            {
                new MeshInstance(this,
                    SurfaceManager.Instance.Mesh, SurfaceManager.Instance.MeshTransform,
                    new Vector3(0, 0, x * 4 - 20), 0.03f);
            }
        }

        public void Add(GameObject gameObject)
        {
            this.gameObjects.Add(gameObject);
        }

        public void Update(UpdateEventArgs args)
        {
            var elapsedTime = new TimeSpan(args.ElapsedTimeInS);

            this.time += elapsedTime;


            foreach (var gameObject in this.gameObjects)
            {
                gameObject.Update(elapsedTime);
            }
        }

        public void Render()
        {
            foreach (var gameObject in this.gameObjects)
            {
                gameObject.Draw();
            }
        }
    }
}