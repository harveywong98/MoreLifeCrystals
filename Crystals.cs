using Terraria.WorldBuilding;
namespace MoreLifeCrystals;

public class Crystals : ModSystem
{
    public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
    {
        int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Life Crystals"));
        if (ShiniesIndex != -1)
            tasks.Insert(ShiniesIndex + 1, new PassLegacy(nameof(MoreLifeCrystals), LifeCrystals));
    }

    private void LifeCrystals(GenerationProgress progress, GameConfiguration configuration)
    {
        progress.Message = "Adding even more life crystals";

        var amount = 100;

        for (int n = 0; n < amount; n++)
        {
            for (var k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
            {
                var x = WorldGen.genRand.Next(50, Main.maxTilesX - 50);
                var y = WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY);
                WorldGen.AddLifeCrystal(x, y);
            }
        }
    }
}
