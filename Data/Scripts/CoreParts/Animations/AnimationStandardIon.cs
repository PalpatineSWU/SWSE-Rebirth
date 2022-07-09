using System.Collections.Generic;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.AnimationDef;
using static Scripts.Structure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static Scripts.Structure.WeaponDefinition.AnimationDef.RelMove;
namespace Scripts
{ // Don't edit above this line
    partial class Parts
    {
        private AnimationDef AnimationSmallIon => new AnimationDef
        {

            AnimationSets = new[]
            {
				#region Muzzles Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("ImpIonCan_Ele"),
                    BarrelId = "", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 60, OffDelay: 30, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
					TriggerOnce = Events(TurnOn, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [TurnOn] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                   LinearPoints = new[]
                                    {
                                        Transformation(0, 0, -1.6f), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },
                        [TurnOff] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 100, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                   LinearPoints = new[]
                                    {
                                        Transformation(0, 0, 1.6f), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },
                        
                    }
                },
               
				#endregion


            }
        };
        private AnimationDef AnimationMedium => new AnimationDef
        {

            AnimationSets = new[]
            {
				#region Muzzles Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("HIC_Rot"),
                    BarrelId = "", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0, StopTrackingDelay:0, InitDelay:0),//Delay before animation starts
                    Reverse = Events(),
                    Loop = Events(),
					TriggerOnce = Events(TurnOn, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        // Reloading, Firing, Tracking, Overheated, TurnOn, TurnOff, BurstReload, NoMagsToLoad, PreFire, EmptyOnGameLoad, StopFiring, StopTracking, LockDelay, Init
                        [TurnOn] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 300, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                   LinearPoints = new[]
                                    {
                                        Transformation(0, 2.6, 0f), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0f), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },
                        [TurnOff] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 300, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                   LinearPoints = new[]
                                    {
                                        Transformation(0, -2.6, 0f), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },
                        
                    }
                },
               
				#endregion


            }
        };
    }
}
