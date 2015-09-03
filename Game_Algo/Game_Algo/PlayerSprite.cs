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
        public PlayerSprite(Texture2D textureImage, Vector2 position, Vector2 speed, Point spriteSize, 
            Point sheetSize, Map gameMap)
            : base(textureImage, position, speed, spriteSize, sheetSize, gameMap)
        { }

        private void UpdateMovement()
        {
            direction = Vector2.Zero;

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.Y -= 1;
                MoveIfWalkable(inputDirection);
                direction += inputDirection;
            }
            if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.Y += 1;
                MoveIfWalkable(inputDirection);
                direction += inputDirection;
            }
            if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.X -= 1;
                MoveIfWalkable(inputDirection);
                direction += inputDirection;
            }
            if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D))
            {
                Vector2 inputDirection = Vector2.Zero;
                inputDirection.X += 1;
                MoveIfWalkable(inputDirection);
                direction += inputDirection;
            }
        }

        public override void Update(GameTime gameTime)
        {
            UpdateMovement();

            base.Update(gameTime);
        }

    }
}
