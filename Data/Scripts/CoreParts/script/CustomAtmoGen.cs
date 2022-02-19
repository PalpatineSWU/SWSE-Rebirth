using System;
using Sandbox.Game.Entities;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRage.Utils;
using VRageMath;
using Sandbox.Game;
using VRage;
using Sandbox.Common.ObjectBuilders;

namespace Klime.CustomAtmoGen
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_OxygenGenerator), false,"K_SWMasterFile_TibannaAccumulator")]
    public class CustomAtmoGen : MyGameLogicComponent
    {
        IMyGasGenerator gas_gen;
        string planet_subtype = "X635";
        string ore_subtype = "Tibanna_Raw";
        MyFixedPoint amount_per_minute = 10;

        //Core
        int timer = 0;
        IMyInventory gas_cargo;
        MyObjectBuilder_Ore ore = new MyObjectBuilder_Ore();

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            if (MyAPIGateway.Session.IsServer)
            {
                gas_gen = Entity as IMyGasGenerator;
                NeedsUpdate = MyEntityUpdateEnum.BEFORE_NEXT_FRAME;
            }
        }

        public override void UpdateOnceBeforeFrame()
        {
            if (gas_gen.CubeGrid.Physics != null)
            {
                ore.SubtypeName = ore_subtype;
                NeedsUpdate = MyEntityUpdateEnum.EACH_100TH_FRAME;
            }
        }

        public override void UpdateAfterSimulation100()
        {
            try
            {
                if (timer % 3600 == 0)
                {
                    if (MyVisualScriptLogicProvider.IsPlanetNearby(gas_gen.WorldMatrix.Translation) && gas_gen.IsFunctional)
                    {
                        MyPlanet test_planet = MyGamePruningStructure.GetClosestPlanet(gas_gen.WorldMatrix.Translation);
                        if (test_planet != null && test_planet.Generator.Id.SubtypeName.ToLower().Contains(planet_subtype.ToLower()))
                        {
                            gas_cargo = gas_gen.GetInventory();
                            if (gas_cargo != null)
                            {
                                gas_cargo.AddItems(amount_per_minute, ore);
                            }
                        }
                    }
                }
                timer += 100;
            }
            catch (Exception e)
            {
                MyLog.Default.WriteLine("KLIME: CustomAtmoGen" + e);
            }
        }

        public override void Close()
        {

        }
    }
}