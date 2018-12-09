using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace MoreLifeCrystals
{
    class Crystals : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Life Crystals"));
            if (ShiniesIndex != -1)
            {
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("More Life Crystals", LifeCrystals));
            }
        }

        private void LifeCrystals(GenerationProgress progress)
        {
            progress.Message = "Adding Even More Life Crystals";

            CrystalGeneration(40);
        }

        private void CrystalGeneration(int amount)
        {
            for (int n = 0; n < amount; n++)
            {
                for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
                {
                    int x = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
                    int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow + 50, Main.maxTilesY - 50); // WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
                    WorldGen.AddLifeCrystal(x, y);
                }
            }

        }
    }
}
