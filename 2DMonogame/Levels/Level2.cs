﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace _2DMonogame.Levels
{
    /// <summary>
    /// Verantwoordelijk voor de array van level2
    /// </summary>
    class Level2 : Level
    {
        public Level2(ContentManager content) : base(content)
        {

        }

        /// <summary>
        /// Maakt nieuwe array aan voor level 2 
        /// </summary>
        protected override void CreateArray()
        {
            TileArray = new byte[,]
           {
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 01,23,23,23,25,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 03,00,00,00,00,00,00,00,00,00,00,00,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,00,00,00,00,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,00,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 01,00,00,00,00,00,00,00,00,00,40,00,40,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,00,00,00,00,00,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,40,00,00,40,0,0,0,0,0,0,0,0,0,00,00,0,00,0,00,0,00,0,00,00,40,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 }
           };
        }
    }
}
