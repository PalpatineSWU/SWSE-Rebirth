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
        private AnimationDef Rebellion_Turrets_Underground_Animation_1 => new AnimationDef
        {

            AnimationSets = new[]
            {
				#region Muzzles Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("REBPopupTurret_Mechanism_II"),
                    BarrelId = "Any", //only used for firing events, use "Any" for all muzzles, muzzle triggers only this animation if not Any
                    AnimationDelays = Delays(FiringDelay : 15, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 30, LockedDelay: 0, OnDelay: 60, OffDelay: 30, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0),//Delay before animation starts
                    Reverse = Events(),
					TriggerOnce = Events(Tracking, StopTracking),
                    Loop = Events(),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                         [Tracking] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                   LinearPoints = new[]
                                    {
                                        Transformation(0, 2f, 0), //linear movement
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotation is around CenterEmpty
                                },
                            },
                        [StopTracking] = new[] //Firing, Reloading, etc, see Possible Events,  define a new[] for each
                            {
                                new RelMove
                                {
                                    CenterEmpty = "",
                                    EmissiveName = "", //EmissiveName: from above Emissives definitions, TurnOn TurnOff
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second
                                    MovementType = Linear,
                                    LinearPoints = new[]
                                    {
                                        Transformation(0, -2f, 0), //linear movement
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
