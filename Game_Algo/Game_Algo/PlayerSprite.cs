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
        public PlayerSprite(Texture2D textureImage, Vector2 position, Point spriteSize, Point sheetSize)
            : base(textureImage, position, spriteSize, sheetSize)
        { }

        public override Vector2 velocity
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;
                
                KeyboardState ks = Keyboard.GetState();
                if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W))
                    inputDirection.Y -= 1;
                if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S))
                    inputDirection.Y += 1;
                if (ks.IsKeyDown(Keys.Left) || ks.IsKeyDown(Keys.A))
                    inputDirection.X -= 1;
                if (ks.IsKeyDown(Keys.Right) || ks.IsKeyDown(Keys.D))
                    inputDirection.X += 1;

                // velocity
                return inputDirection * speed;
            }
        }

        public override void Update(GameTime gameTime)
        {
            // Move the sprite based on velocity
            position += velocity;

            base.Update(gameTime);
        }
    }
}
