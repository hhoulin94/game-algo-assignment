﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game_Algo
{
    static class GameSetting
    {
        static public Point PlayerStartPosition = new Point(28, 1);

        static public Point MapSize = new Point(30, 20); // how many Tiles

        static public Point TileSize = new Point(30, 30); // Tile dimensions (30px x 30px)
        static public Texture2D TileTextureSheet;
        
        static public Point WindowSize
        {
            get
            {
                Point windowSize = Point.Zero;
                windowSize.X = TileSize.X * MapSize.X;
                windowSize.Y = TileSize.Y * MapSize.Y;
                return windowSize;
            }
        }

        public struct MapLayout
        {
            static public string Level_01 =
                "##############################" + // 0
                "#        #   #   #   #   #   #" + // 1
                "#        #   #   #   #   #   #" + // 2
                "#        ### ### ### ### ### #" + // 3
                "#        #                   #" + // 4
                "#        #                   #" + // 5
                "#        #  #####  ######## ##" + // 6
                "#        #  #   #  #         #" + // 7
                "#        #  #                #" + // 8
                "#        #  ##################" + // 9
                "#        #                   #" + // 10
                "#        #                   #" + // 11
                "#        #                   #" + // 12
                "#        #             #     #" + // 13
                "#        #                   #" + // 14
                "#        #                   #" + // 15
                "#        #######             #" + // 16
                "#                # # #       #" + // 17
                "#                            #" + // 18
                "##############################";  // 19
        }

        static public Vector2 PointToVector2(Point PointOnMap)
        {
            return new Vector2(PointOnMap.X * TileSize.X, PointOnMap.Y * TileSize.Y);
        }
        
    }
}