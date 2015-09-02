using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game_Algo
{
    class Tile
    {
        /// <summary>
        /// 0 - Floor
        /// 1 - Wall
        /// </summary>
        public int TypeId { get; set; }

        public Tile(int MapCellId)
        {
            this.TypeId = MapCellId;
        }

        public bool Walkable
        {
            get
            {
                return (TypeId == GameSetting.TileType.Wall) ? false : true;
            }
        }

    }
}
