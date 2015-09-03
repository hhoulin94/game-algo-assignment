using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Algo
{
    abstract class Sprite
    {
        Texture2D textureImage;
        protected Point spriteSize;
        Point currentFrame;
        Point sheetSize;
        int collisionOffset;
        int timeSinceLastFrame = 0;
        int millisecondsPerFrame;
        const int defaultMillisecondsPerFrame = 16;
        protected Vector2 speed;
        public Vector2 direction;
        public Vector2 position;
        protected Map gameMap;

        // public abstract Vector2 direction { get; }

        public Sprite(Texture2D textureImage, Vector2 position, Vector2 speed, Point spriteSize, Point sheetSize, Map gameMap)
            : this(textureImage, position, speed, spriteSize, sheetSize, gameMap,
              10, new Point(0, 0), defaultMillisecondsPerFrame)
        { }

        public Sprite(Texture2D textureImage, Vector2 position, Vector2 speed, Point spriteSize, Point sheetSize, Map gameMap,
            int collisionOffset, Point currentFrame)
            : this(textureImage, position, speed, spriteSize, sheetSize, gameMap, collisionOffset,
              currentFrame, defaultMillisecondsPerFrame)
        { }

        public Sprite(Texture2D textureImage, Vector2 position, Vector2 speed, Point spriteSize, Point sheetSize, Map gameMap,
            int collisionOffset, Point currentFrame, int millisecondsPerFrame)
        {
            this.textureImage = textureImage;
            this.position = position;
            this.spriteSize = spriteSize;
            this.sheetSize = sheetSize;
            this.collisionOffset = collisionOffset;
            this.currentFrame = currentFrame;
            this.speed = speed;
            this.millisecondsPerFrame = millisecondsPerFrame;
            this.gameMap = gameMap;
        }

        public virtual void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame = 0;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                    ++currentFrame.Y;
                    if (currentFrame.Y >= sheetSize.Y)
                        currentFrame.Y = 0;
                }
            }
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureImage,
            position,
            new Rectangle(currentFrame.X * spriteSize.X,
            currentFrame.Y * spriteSize.Y,
            spriteSize.X, spriteSize.Y),
            Color.White, 0, Vector2.Zero,
            1f, SpriteEffects.None, 0);
        }

        public Rectangle collisionRect
        {
            get
            {
                return new Rectangle(
                (int)position.X + collisionOffset,
                (int)position.Y + collisionOffset,
                spriteSize.X - (collisionOffset * 2),
                spriteSize.Y - (collisionOffset * 2));
            }
        }

        protected void MoveIfWalkable(Vector2 inputDirection)
        {
            if (gameMap.CheckTileWalkable(position + inputDirection))
                position += inputDirection * speed;
        }

    }
}
