using _2DMonogame.Blocks;
using _2DMonogame.Blocks.Collectable;
using _2DMonogame.Blocks.DeathBlocks;
using _2DMonogame.Blocks.InvisibleBlocks;
using _2DMonogame.Blocks.MovingBlocks;
using _2DMonogame.Blocks.RunThroughBlocks;
using _2DMonogame.Blocks.StaticBlocks;
using _2DMonogame.Button;
using _2DMonogame.Characters;
using _2DMonogame.Collision;
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
        protected override GameObject CreateBlock(int id, ContentManager content)
        {
            GameObject b = null;
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
            else if (id == 13)
                b = new BoxFirstVariant(content, "box1");
            else if (id == 14)
                b = new BoxSecondVariant(content, "box2");
            else if (id == 15)
                b = new Scarecrow(content, "scarecrow");
            else if (id == 16)
                b = new Pointer(content, "pointer");
            else if (id == 17)
                b = new OrangeTree(content, "tree1");
            else if (id == 18)
                b = new YellowTree(content, "tree2");
            else if (id == 19)
                b = new MovingBlock(content, "plate1");
            else if (id == 20)
                b = new MovingBlock(content, "plate1") { Invert = true };
            else if (id == 21)
                b = new StarCollectable(content, "star");
            else if (id == 22)
                b = new BouncingAcidBall(content, "LavaFireballSprite");
            else if (id == 23)
                b = new UpUnderBlock(content, "bovenonder");
            else if (id == 24)
                b = new LeftOverRoofBlock(content, "linksoverkaping");
            else if (id == 25)
                b = new RightOverRoofBlock(content, "rechtsoverkaping");
            else if (id == 26)
                b = new UnderBlock(content, "13");
            else if (id == 27)
                b = new FullBlock(content, "11");
            else if (id == 30)
                b = new GreenGoblin(content, "GreenGoblinSprite");
            else if (id == 31)
                b = new Giant(content, "GiantSprite");
            else if (id == 32)
                b = new Orc(content, "BlackGoblin");
            else if (id == 33)
                b = new BlueGoblin(content, "BlueMonster");
            else if (id == 40)
                b = new InvisibleBlock(content, "legeBlok");
            else if (id == 50)
                b = new ButtonNextLevel(content, "button");
            return b;
        }

 
    }
}
