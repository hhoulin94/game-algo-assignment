using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Algo
{
    static class TileTexture
    {
        static public Texture2D TextureSheet = GameSetting.TileTextureSheet;

        static public Rectangle GetTextureRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TextureSheet.Width / GameSetting.TileSize.X);
            int tileX = tileIndex % (TextureSheet.Width / GameSetting.TileSize.X);

            return new Rectangle(tileX * GameSetting.TileSize.X, tileY * GameSetting.TileSize.Y, 
                GameSetting.TileSize.X, GameSetting.TileSize.Y);
        }
        
    }
}
