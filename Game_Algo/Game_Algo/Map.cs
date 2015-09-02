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
        public List<TileRow> Rows = new List<TileRow>();

        public Map()
        {
            int mapStringIndex = 0;
            string mapString = GameSetting.MapLayout.Level_01;

            for (int y = 0; y < GameSetting.MapSize.Y; y++)
            {
                TileRow thisRow = new TileRow();
                for (int x = 0; x < GameSetting.MapSize.X; x++)
                {
                    Tile mapCell = parseMapChar(mapString[mapStringIndex]);
                    thisRow.Columns.Add(mapCell);
                    mapStringIndex++;
                }
                Rows.Add(thisRow);
            }
        }

        private Tile parseMapChar(char mapChar)
        {
            int cellTypeId = 0;

            switch (mapChar)
            {
                case ' ':
                    cellTypeId = 0;
                    break;
                case '#':
                    cellTypeId = 1;
                    break;
                default:
                    break;
            }

            return new Tile(cellTypeId);
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
                        TileTexture.GetTextureRectangle(Rows[y].Columns[x].TypeId),
                        Color.White);
                }
            }
        }

        public bool CheckTileWalkable(Vector2 WalkPosition)
        {
            for (int y = 0; y < GameSetting.MapSize.Y; y++)
            {
                for (int x = 0; x < GameSetting.MapSize.X; x++)
                {
                    Rectangle currentTile = new Rectangle(GameSetting.TileSize.X * x, GameSetting.TileSize.Y * y,
                                                          GameSetting.TileSize.X,     GameSetting.TileSize.Y);

                    Rectangle currentPlayerPosition = new Rectangle((int)WalkPosition.X, (int)WalkPosition.Y,
                                                                    GameSetting.TileSize.X, GameSetting.TileSize.Y);

                    if (currentTile.Intersects(currentPlayerPosition))
                    {
                        Tile intersectingTile = Rows[y].Columns[x];
                        if (!intersectingTile.Walkable)
                            return false;
                    }
                }
            }

            return true;
        }
    }
}
