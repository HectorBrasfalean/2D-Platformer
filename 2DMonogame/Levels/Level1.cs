﻿using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    /// <summary>
    /// Verantwoordelijk voor de array die level 1 zal voorstellen
    /// </summary>
    class Level1 : Level
    {

        public Level1(ContentManager content) : base(content)
        {
        }
        /// <summary>
        /// Maakt een array voor level 1 aan
        /// </summary>
        protected override void CreateArray()
        {
            TileArray = new byte[,]
            {
                { 0,00,00,0,0,00,00,00,0,00,0,0,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,0,00,00,00,0,0,0,00,0,0,00,0,0,00,0,00,21,21,0,21,21,00,00,0,00,21,0,00,0,0,00,0,0,0,00,00,00,0,0,0,0,0,0,00,0,0,0,0,0,0,0,0,0,0,0,0,00,0,30,0,00,0,00,0,00,0,0,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 0,00,00,0,0,00,00,00,0,00,0,0,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,0,00,00,00,0,0,0,00,0,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,0,21,0,0,00,0,0,0,00,00,00,0,0,0,0,0,0,00,0,0,0,0,0,0,0,0,0,0,0,0,00,0,00,0,30,0,30,0,00,0,0,00,0,0,00,0,0,00,00,00,0,0,0,0,0,0,0,0,0,0,00,00,0,0,0,0,0 },
                { 0,00,00,0,0,00,00,00,0,00,0,0,00,0,00,0,00,21,0,0,0,00,0,0,0,21,0,0,0,0,21,21,21,0,0,0,00,0,0,21,0,4,00,0,19,00,19,0,20,00,20,00,0,00,05,0,00,0,0,21,0,0,0,00,00,00,0,0,0,0,0,0,21,0,0,0,0,0,0,0,0,0,0,0,0,00,0,00,0,00,0,00,0,00,0,0,00,0,0,00,0,0,00,21,00,0,0,0,0,0,0,0,0,0,0,21,21,0,0,0,0,0 },
                { 3,00,00,0,0,00,00,00,0,00,0,0,00,0,00,0,00,00,0,0,0,00,0,0,0,00,0,0,0,0,00,00,00,0,0,0,16,0,0,00,4,1,06,7,07,07,07,7,07,07,07,07,7,08,01,2,05,0,0,00,0,0,0,21,00,00,0,0,0,0,0,0,12,0,0,0,0,0,0,0,0,0,0,0,0,00,0,30,0,00,0,00,0,00,0,0,00,0,0,21,0,0,21,00,00,0,0,0,0,0,0,0,0,0,0,12,12,0,0,0,0,0 },
                { 3,00,00,0,0,00,21,00,0,21,0,0,21,0,00,0,13,00,0,0,0,21,0,0,4,02,5,0,0,0,12,12,12,0,0,0,00,0,0,04,1,1,01,1,01,01,01,1,01,01,01,01,1,01,01,1,01,2,0,00,0,0,0,00,00,00,4,2,2,5,0,0,21,0,0,4,2,5,0,0,0,0,0,0,0,00,0,00,0,00,0,30,0,00,0,0,21,0,0,00,0,0,12,00,00,0,0,4,2,2,2,2,2,5,0,00,00,0,0,0,0,0 },
                { 3,30,15,0,0,00,00,00,0,00,0,0,00,0,14,4,02,02,2,5,0,00,0,4,1,01,1,5,0,0,30,00,21,0,0,4,02,5,0,00,0,0,30,0,00,30,00,0,30,00,00,30,0,00,00,0,00,0,0,13,0,0,0,12,00,21,9,1,1,3,0,0,12,0,0,9,1,3,0,0,0,0,0,0,0,00,0,00,0,18,0,00,0,00,0,0,00,0,0,12,0,0,00,00,12,0,0,9,1,1,1,1,1,3,0,00,00,0,4,2,2,0 },
                { 3,00,00,0,0,13,04,05,0,19,0,0,20,0,04,1,01,01,1,3,0,12,0,9,1,01,1,1,5,0,00,00,14,0,0,9,01,3,0,17,0,0,18,0,00,17,00,0,18,00,00,17,0,00,00,0,00,0,4,02,5,0,0,00,21,14,9,1,1,3,0,0,00,0,0,9,1,1,2,5,0,0,0,0,0,14,0,00,0,00,0,00,0,13,0,0,12,0,0,00,0,0,00,00,00,0,0,9,1,1,1,1,1,1,2,02,02,2,1,1,1,0 },
                { 1,02,02,2,2,02,01,03,0,00,0,0,00,0,09,1,01,01,1,1,6,07,8,1,1,01,1,1,1,2,02,02,06,7,8,1,01,3,0,00,0,0,00,0,00,00,00,0,00,00,00,00,0,00,00,4,02,2,1,01,1,5,0,21,14,13,9,1,1,1,6,7,07,7,8,1,1,1,1,1,2,5,0,0,0,04,2,02,2,02,2,02,2,05,0,0,00,0,0,00,0,0,00,00,00,0,0,9,1,1,1,1,1,1,1,01,01,1,1,1,1,0 },
                { 1,01,01,1,1,01,01,01,6,07,7,7,07,8,01,1,01,01,1,1,1,01,1,1,1,01,1,1,1,1,01,01,01,1,1,1,01,1,2,02,2,2,02,2,02,02,02,2,02,02,02,02,2,02,02,1,01,1,1,01,1,1,2,02,02,02,1,1,1,1,1,1,01,1,1,1,1,1,1,1,1,1,2,2,2,01,1,01,1,01,1,01,1,03,6,7,07,7,7,07,7,7,07,07,07,7,8,1,1,1,1,1,1,1,1,01,01,1,1,1,1,0 },
            };
        }
    }
            // 1 is DirtBlock
            // 2 is GrassTopBlock
            // 3 is GrassRightBlock
            // 4 is LeftTopCornerBlock
            // 5 is RightTopCornerBlock
            // 6 is Acid LeftBottomDirt 
            // 7 is Acid BottomDirt
            // 8 Acid RightBottomDirt 
            // 9 GrassLeft
            // 10 LeftBottomCorner
            // 11 RightBottomCorner
            // 12 Platform
            // 13 Box
            // 14 Box 2nd
            // 15 Scarecrow
            // 16 Pointer
            // 17 Tree
            // 18 Tree 2nd
            // 19 Moving Platform
 
}
