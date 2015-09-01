using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Algo
{
    class Map
    {
        public List<MapRow> Rows = new List<MapRow>();
        public int Width = GameSetting.MapSize.X;
        public int Height = GameSetting.MapSize.Y;

        public Map()
        {
            string map = GameSetting.MapLayout.Level_01;

            int mapIndex = 0;

            for (int y = 0; y < Height; y++)
            {
                MapRow thisRow = new MapRow();
                for (int x = 0; x < Width; x++)
                {
                    if (map[mapIndex].Equals('#'))
                    {
                        thisRow.Columns.Add(new MapCell(2));
                        mapIndex++;
                    }
                    else if (map[mapIndex].Equals(' '))
                    {
                        thisRow.Columns.Add(new MapCell(3));
                        mapIndex++;
                    }
                    else
                    {
                        thisRow.Columns.Add(new MapCell(3));
                        mapIndex++;
                    }
                }
                Rows.Add(thisRow);
            }
        }

        public MapCell GetTileID(Vector2 WalkPosition) {

            List<MapCell> IntersectTileID = new List<MapCell> ();
            
            for (int y = 0; y < Height; y++)
            {
               
                for (int x = 0; x < Width; x++)
                {
                    Rectangle CurrentTile = new Rectangle(x * 32 , y * 32 , 32 , 32);
                    Rectangle CurrentPlayerPosition = new Rectangle((int)WalkPosition.X , (int)WalkPosition.Y , 32 , 32);
                    
                    if (CurrentTile.Intersects(CurrentPlayerPosition))
                    {
                        IntersectTileID.Add(Rows[y].Columns[x]); 
                    }
                }
               
            }
            int counter = 0 ;

            foreach(MapCell CantWalk in IntersectTileID){
                if (CantWalk.Id == 2 || counter == IntersectTileID.Count - 1)
                {
                    return CantWalk; 
                }
            }

            return null; 
        }

        public bool Walkable(Vector2 WalkPosition) {

            if (GetTileID(WalkPosition) == null)
                return true;

            if (GetTileID(WalkPosition).Id == 2)
                return false; 
            
            else
                return true;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < GameSetting.MapSize.Y; y++)
            {
                for (int x = 0; x < GameSetting.MapSize.X; x++)
                {
                    spriteBatch.Draw(
                        TileTexture.TextureSheet,
                        new Rectangle(
                            (x * GameSetting.TileSize.X),
                            (y * GameSetting.TileSize.Y),
                            GameSetting.TileSize.X, GameSetting.TileSize.Y),
                        TileTexture.GetTextureRectangle(Rows[y].Columns[x].Id),
                        Color.White);
                }
            }
        }
    }
}
