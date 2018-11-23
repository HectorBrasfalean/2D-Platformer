using _2DMonogame.Blocks;
using _2DMonogame.Blocks.StaticBlocks;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DMonogame
{
    class LevelFactory : AbstractLevelFactory
    {
        protected override StaticBlock CreateBlock(int id, ContentManager content)
        {
            StaticBlock b = null;
            if (id == 1)
                b = new DirtBlock(content, "01");
            else if (id == 2)
                b = new GrassTopBlock(content, "04");
            else if (id == 3)
                b = new GrassRightBLock(content, "08");
            else if (id == 4)
                b = new LeftTopCornerBlock(content, "03");
            else if (id == 5)
                b = new RightTopCornerBlock(content, "02");
            else if (id == 6)
                b = new AcidMudLeftAndBottomBlock(content, "19");
            else if (id == 7)
                b = new AcidMudBottomBlock(content, "15");
            else if (id == 8)
                b = new AcidMudRightAndBottomBlock(content, "22");
            else if (id == 9)
                b = new GrassLeftBlock(content, "07");
            else if (id == 10)
                b = new LeftBottomCornerBlock(content, "10");
            else if (id == 11)
                b = new RightBottomCornerBlock(content, "09");
            else if (id == 12)
                b = new PlatformBlock(content, "plate1");
            
            return b;
        }
    }
}
