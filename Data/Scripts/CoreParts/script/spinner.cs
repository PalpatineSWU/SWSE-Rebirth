using System;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Game;
using Sandbox.ModAPI;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.Entity;
using VRage.Game.ModAPI;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using VRageMath;

namespace EquinoxStuff
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_MedicalRoom), false, "K_Imperial_SpawnPoint_Beacon_I","K_Imperial_SpawnPoint_Globe_I", "K_CIS_SpawnPoint_Beacon_I" )]
    public class MedicalSpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public MedicalSpinner() : base("dummy", 10 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }
	
	[MyEntityComponentDescriptor(typeof(MyObjectBuilder_RadioAntenna), false, "K_Imperial_Antenna_I", "K_Imperial_ShieldGeneratorProp", "K_Imperial_Antenna_II", "K_Imperial_MG_Relay_Spawner" )]
    public class AntennaSpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public AntennaSpinner() : base("dummy", 10 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }
	
		
	
	[MyEntityComponentDescriptor(typeof(MyObjectBuilder_HydrogenEngine), false, "K_Imperial_Reactors_Hypermatter_Medium", "K_Imperial_Reactors_Hypermatter_Heavy" )]
    public class HydroEngineSpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public HydroEngineSpinner() : base("dummy", 40 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }
	
	[MyEntityComponentDescriptor(typeof(MyObjectBuilder_Reactor), false, "K_Imperial_Reactors_Exonium_Large_LG", "K_Rebellion_Generator_Synth", "K_Imperial_Reactors_Exonium_PowerCoreHeavy" )]
    public class MiningUnitSpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public MiningUnitSpinner() : base("dummy", 60 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }
	
	[MyEntityComponentDescriptor(typeof(MyObjectBuilder_Refinery), false, "K_Imperial_Civ_MiningUnit_Main", "K_Imperial_Refinement_Refinery_Light_I", "K_Imperial_Civ_MiningUnit_Small" )]
    public class RefineryASpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public RefineryASpinner() : base("dummy", 45 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }
	
	
	 [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Reactor), false, "K_Imperial_Reactors_SythFuel_Basic", "K_Imperial_Reactors_Exonium_Small_LG" )]
    public class ReactorSpinner : EnabledSpinner
    {
        // Spin SubpartName at 10 degrees per second
        public ReactorSpinner() : base("dummy", 90 * (float) Math.PI / 180.0f * MyEngineConstants.UPDATE_STEP_SIZE_IN_SECONDS)
        {
        }
    }

    public abstract class EnabledSpinner : MyGameLogicComponent
    {
        private readonly float _idleSpeed;
        private readonly string _subpart;

        protected EnabledSpinner(string subpart, float idleSpeed)
        {
            _subpart = subpart;
            _idleSpeed = idleSpeed;
        }

        public override string ComponentTypeDebugString => nameof(EnabledSpinner);

        public override void OnAddedToContainer()
        {
            if (MyAPIGateway.Utilities.IsDedicated)
                return;
            base.OnAddedToContainer();
            var block = Entity as IMyFunctionalBlock;
            if (block != null)
                block.EnabledChanged += EnabledChanged;
        }

        public override void OnBeforeRemovedFromContainer()
        {
            if (MyAPIGateway.Utilities.IsDedicated)
                return;
            var block = Entity as IMyFunctionalBlock;
            if (block != null)
                block.EnabledChanged -= EnabledChanged;
            base.OnBeforeRemovedFromContainer();
        }

        private void EnabledChanged(IMyTerminalBlock obj)
        {

            NeedsUpdate = ((IMyFunctionalBlock)obj).Enabled ? MyEntityUpdateEnum.EACH_FRAME : MyEntityUpdateEnum.NONE;
        }

        private IMyModel _activeModel;
        private MyEntitySubpart _activeSubpart;

        //Changes made by Stollie at request of Kreeg.
        public override void UpdateAfterSimulation()
        {

            if (Entity != null)
            {
                _activeModel = Entity.Model;
                Entity.TryGetSubpart(_subpart, out _activeSubpart);
            }

            if (_activeSubpart?.PositionComp == null) return;

            var m = _activeSubpart.PositionComp.LocalMatrix;
            m *= Matrix.CreateRotationY(_idleSpeed);
            _activeSubpart.PositionComp.LocalMatrix = Matrix.Normalize(m);
        }
    }
}