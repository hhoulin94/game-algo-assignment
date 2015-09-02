using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game_Algo
{
    class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        PlayerSprite player;
        List<Sprite> guardsList = new List<Sprite>();

        Map gameMap;

        public SpriteManager(Game game, Map gameMap)
            : base(game)
        {
            this.gameMap = gameMap;
        }

        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            player = new PlayerSprite(
                Game.Content.Load<Texture2D>(@"Textures\Sprites\Player"),
                GameSetting.PointToVector2(GameSetting.PlayerStartPosition), //position
                GameSetting.TileSize, // dimensions
                new Point(1, 1), // sheet size
                gameMap
                );

            //guardsList.Add(new GuardSprite(
            //    Game.Content.Load<Texture2D>(@"Textures\Sprites\Player"),
            //    Vector2.Zero,  //position
            //    MapSettings.TileSize, // dimensions
            //    new Point(1, 1) // sheet size
            //    );

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // Update player
            player.Update(gameTime);

            // Update guards
            //foreach (Sprite s in guardsList)
            //{
            //    s.Update(gameTime, gameMap);
            //    // Check for collisions and exit game if there is one
            //    if (s.collisionRect.Intersects(player.collisionRect))
            //        Game.Exit();
            //}

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // Draw the player
            player.Draw(gameTime, spriteBatch);

            // Draw all sprites
            foreach (Sprite s in guardsList)
                s.Draw(gameTime, spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }


        // Return current position of the player sprite
        public Vector2 GetPlayerPosition()
        {
            return player.position;
        }
    }
}
