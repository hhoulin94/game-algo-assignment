using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Algo
{
    class GuardSprite : Sprite
    {
        // Save a reference of SpriteManager to track player position
        SpriteManager spriteManager;

        string state = "guard"; 

        public GuardSprite(Texture2D textureImage, Vector2 position, Vector2 speed, Point spriteSize, 
            Point sheetSize, Map gameMap, SpriteManager spriteManager)
            : base(textureImage, position, speed, spriteSize, sheetSize, gameMap)
        {
            this.spriteManager = spriteManager;
        }

        private Vector2 PlayerPosition
        {
            get
            {
                return spriteManager.GetPlayerPosition();
            }
        }

        private Vector2 PlayerDirection
        {
            get
            {
                return spriteManager.GetPlayerDirection();
            }
        }

        private float WaitTimeToChase = 0;
        public override void Update(GameTime gameTime)
        {
            //if (HasToShowCard())
            //{
            //    WaitTimeToChase = 1;
            //}

            //if (WaitTimeToChase > 0)
            //{
            //    WaitTimeToChase -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            //    if (WaitTimeToChase <= 0)
            //    {
            //        WaitTimeToChase = 0;
            //        ChaseState();
            //    }
            //}


            ChaseState();

            base.Update(gameTime);
        }

        private void ChaseState()
        {
            // If the player is moving vertically, chase horizontally
            if (true)
            {
                if (PlayerPosition.X < position.X)
                    MoveIfWalkable(new Vector2(-1, 0));
                else if (PlayerPosition.X > position.X)
                    MoveIfWalkable(new Vector2( 1, 0));
            }

            // If the PlayerPosition is moving horizontally, chase vertically
            if (true)
            {
                if (PlayerPosition.Y < position.Y)
                    MoveIfWalkable(new Vector2(0, -1));
                else if (PlayerPosition.Y > position.Y)
                    MoveIfWalkable(new Vector2(0, 1));
            }
        }

    }
}
