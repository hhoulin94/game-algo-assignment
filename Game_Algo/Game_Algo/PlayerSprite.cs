using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Algo
{
    class PlayerSprite : Sprite
    {
        public PlayerSprite(Texture2D textureImage, Vector2 position, Point spriteSize, Point sheetSize, Map gameMap)
            : base(textureImage, position, spriteSize, sheetSize, gameMap)
        { }

        private void UpdateMovement()
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.Y -= 1;
                if (gameMap.CheckTileWalkable(position + inputDirection))
                    position += inputDirection * speed;
            }
            if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.Y += 1;
                if (gameMap.CheckTileWalkable(position + inputDirection))
                    position += inputDirection * speed;
            }
            if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.X -= 1;
                if (gameMap.CheckTileWalkable(position + inputDirection))
                    position += inputDirection * speed;
            }
            if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.X += 1;
                if (gameMap.CheckTileWalkable(position + inputDirection))
                    position += inputDirection * speed;
            }

            // return inputDirection * speed;
            // return inputDirection;
        }
        private void moveIfWalkable(Vector2 position, Vector2 inputDirection, Vector2 speed)
        {
            if (gameMap.CheckTileWalkable(position + inputDirection))
                position += inputDirection * speed;
        }

        public override void Update(GameTime gameTime)
        {
            // Move the sprite based on velocity
            //Vector2 velocity = direction * speed;
            //// position = (gameMap.CheckTileWalkable(newPosition)) ? newPosition : position;
            //if (gameMap.CheckTileWalkable(position + direction))
            //{
            //    position += velocity;
            //}

            UpdateMovement();

            base.Update(gameTime);
        }

    }
}
