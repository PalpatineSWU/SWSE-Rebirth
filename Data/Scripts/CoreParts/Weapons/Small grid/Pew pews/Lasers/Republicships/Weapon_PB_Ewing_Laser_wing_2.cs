﻿using static Scripts.Structure;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.ModelAssignmentsDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.Prediction;
using static Scripts.Structure.WeaponDefinition.TargetingDef.BlockTypes;
using static Scripts.Structure.WeaponDefinition.TargetingDef.Threat;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef.HardwareType;

namespace Scripts {   
    partial class Parts {
        // Don't edit above this line
        WeaponDefinition NewRepublic_EwingWingLaserCannonB => new WeaponDefinition
        {
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "K_NewRepublic_EWing_WingGunB", // Block Subtypeid. Your Cubeblocks contain this information
                        SpinPartId = "None", // For weapons with a spinning barrel such as Gatling Guns. Subpart_Boomsticks must be written as Boomsticks.
                        MuzzlePartId = "EWing_LaserII_Ele", // The subpart where your muzzle empties are located. This is often the elevation subpart. Subpart_Boomsticks must be written as Boomsticks.
                        AzimuthPartId = "EWing_LaserII_Rot", // Your Rotating Subpart, the bit that moves sideways.
                        ElevationPartId = "EWing_LaserII_Ele",// Your Elevating Subpart, that bit that moves up.
                        DurabilityMod = 1f, // GeneralDamageMultiplier, 0.25f = 25% damage taken.
                        IconName = "Laser turrets.dds" // Overlay for block inventory slots, like reactors, refineries, etc.
                    },        
                 },
                Muzzles = new[] {
                  "muzzle_missile_010", // Where your Projectiles spawn. Use numbers not Letters. IE Muzzle_01 not Muzzle_A
                },
                Ejector = "", // Optional; empty from which to eject "shells" if specified.
                Scope = "EWing_LaserI_Ele", // Where line of sight checks are performed from. Must be clear of block collision.
            },
            Targeting = new TargetingDef
            {
                Threats = new[] {
                    Grids, Projectiles, Characters, // Types of threat to engage: Grids, Projectiles, Characters, Meteors, Neutrals
                },
                SubSystems = new[] {
                    Thrust, Utility, Offense, Power, Production, Any, // Subsystem targeting priority: Offense, Utility, Power, Production, Thrust, Jumping, Steering, Any
                },
                ClosestFirst = true, // Tries to pick closest targets first (blocks on grids, projectiles, etc...).
                IgnoreDumbProjectiles = false, // Don't fire at non-smart projectiles.
                LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.
                MinimumDiameter = 0, // Minimum radius of threat to engage.
                MaximumDiameter = 0, // Maximum radius of threat to engage; 0 = unlimited.
                MaxTargetDistance = 0, // Maximum distance at which targets will be automatically shot at; 0 = unlimited.
                MinTargetDistance = 0, // Minimum distance at which targets will be automatically shot at.
                TopTargets = 4, // Maximum number of targets to randomize between; 0 = unlimited.
                TopBlocks = 8, // Maximum number of blocks to randomize between; 0 = unlimited.
                StopTrackingSpeed = 0, // Do not track threats traveling faster than this speed; 0 = unlimited.
            },
            HardPoint = new HardPointDef
            {
                PartName = "E-Wing Laser", // Name of the weapon in terminal, should be unique for each weapon definition that shares a SubtypeId (i.e. multiweapons).
                DeviateShotAngle = 0.2f, // Projectile inaccuracy in degrees.
                AimingTolerance = 1f, // How many degrees off target a turret can fire at. 0 - 180 firing angle.
                AimLeadingPrediction = Accurate, // Level of turret aim prediction; Off, Basic, Accurate, Advanced
                DelayCeaseFire = 0, // Measured in game ticks (6 = 100ms, 60 = 1 second, etc..). Length of time the weapon continues firing after trigger is released - while a target is available.
                AddToleranceToTracking = false, // Allows turret to track to the edge of the AimingTolerance cone instead of dead centre.
                CanShootSubmerged = false, // Whether the weapon can be fired underwater when using WaterMod.

                Ui = new UiDef
                {
                    RateOfFire = true, // Enables terminal slider for changing rate of fire.
                    DamageModifier = false, // Enables terminal slider for changing damage per shot.
                    ToggleGuidance = false, // Enables terminal option to disable smart projectile guidance.
                    EnableOverload = false, // Enables terminal option to turn on Overload; this allows energy weapons to double damage per shot, at the cost of quadrupled power draw and heat gain, and 2% self damage on overheat.
                },
                Ai = new AiDef
                {
                    TrackTargets = true, // Whether this weapon tracks its own targets, or (for multiweapons) relies on the weapon with PrimaryTracking enabled for target designation. Turrets Need this set to True.
                    TurretAttached = true, // Whether this weapon is a turret and should have the UI and API options for such. Turrets Need this set to True.
                    TurretController = true, // Whether this weapon can physically control the turret's movement. Turrets Need this set to True.
                    PrimaryTracking = true, // For multiweapons: whether this weapon should designate targets for other weapons on the platform without their own tracking.
                    LockOnFocus = false, // If enabled, weapon will only fire at targets that have been HUD selected AND locked onto by pressing Numpad 0.
                    SuppressFire = false, // If enabled, weapon can only be fired manually.
                    OverrideLeads = false, // Disable target leading on fixed weapons, or allow it for turrets.
                },
                HardWare = new HardwareDef
                {
                    RotateRate = 0.0f, // Max traversal speed of azimuth subpart in radians per tick (0.1 is approximately 360 degrees per second).
                    ElevateRate = 0.0f, // Max traversal speed of elevation subpart in radians per tick.
                    MinAzimuth = -90,
                    MaxAzimuth = 90,
                    MinElevation = -20,
                    MaxElevation = 20,
                    HomeAzimuth = 0, // Default resting rotation angle
                    HomeElevation = 0, // Default resting elevation
                    InventorySize = 1f, // Inventory capacity in kL.
                    IdlePower = 0.25f, // Constant base power draw in MW.
                    FixedOffset = false, // Deprecated.
                    Offset = Vector(x: 0, y: 0, z: 0), // Offsets the aiming/firing line of the weapon, in metres.
                    Type = BlockWeapon, // What type of weapon this is; BlockWeapon, HandWeapon, Phantom 
                    CriticalReaction = new CriticalDef
                    {
                        Enable = false, // Enables Warhead behaviour.
                        DefaultArmedTimer = 120, // Sets default countdown duration.
                        PreArmed = false, // Whether the warhead is armed by default when placed. Best left as false.
                        TerminalControls = true, // Whether the warhead should have terminal controls for arming and detonation.
                        AmmoRound = "AmmoType2", // Optional. If specified, the warhead will always use this ammo on detonation rather than the currently selected ammo.
                    },
                },
                Other = new OtherDef
                {
                    ConstructPartCap = 10, // Maximum number of blocks with this weapon on a grid; 0 = unlimited.
                    RotateBarrelAxis = 0, // For spinning barrels, which axis to spin the barrel around; 0 = none.
                    EnergyPriority = 0, // Deprecated.
                    MuzzleCheck = false, // Whether the weapon should check LOS from each individual muzzle in addition to the scope.
                    Debug = false, // Force enables debug mode.
                    RestrictionRadius = 0, // Prevents other blocks of this type from being placed within this distance of the centre of the block.
                    CheckInflatedBox = false, // If true, the above distance check is performed from the edge of the block instead of the centre.
                    CheckForAnyWeapon = false, // If true, the check will fail if ANY weapon is present, not just weapons of the same subtype.
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 120, // Set this to 3600 for beam weapons. This is how fast your Gun fires.
                    BarrelsPerShot = 1, // How many muzzles will fire a projectile per fire event.
                    TrajectilesPerBarrel = 1, // Number of projectiles per muzzle per fire event.
                    SkipBarrels = 0, // Number of muzzles to skip after each fire event.
                    ReloadTime = 1, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MagsToLoad = 1, // Number of physical magazines to consume on reload.
                    DelayUntilFire = 0, // How long the weapon waits before shooting after being told to fire. Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 1, // Heat generated per shot.
                    MaxHeat = 60, // Max heat before weapon enters cooldown (70% of max heat).
                    Cooldown = .80f, // Percentage of max heat to be under to start firing again after overheat; accepts 0 - 0.95
                    HeatSinkRate = 1, // Amount of heat lost per second.
                    DegradeRof = true, // Progressively lower rate of fire when over 80% heat threshold (80% of max heat).
                    ShotsInBurst = 0, // Use this if you don't want the weapon to fire an entire physical magazine in one go. Should not be more than your magazine capacity.
                    DelayAfterBurst = 0, // How long to spend "reloading" after each burst. Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFull = false, // Whether the weapon should fire the full magazine (or the full burst instead if ShotsInBurst > 0), even if the target is lost or the player stops firing prematurely.
                    GiveUpAfter = false, // Whether the weapon should drop its current target and reacquire a new target after finishing its magazine or burst.
                    BarrelSpinRate = 0, // Visual only, 0 disables and uses RateOfFire.
                    DeterministicSpin = false, // Spin barrel position will always be relative to initial / starting positions (spin will not be as smooth).
                    SpinFree = true, // Spin barrel while not firing.
                    StayCharged = false, // Will start recharging whenever power cap is not full.
                    MaxActiveProjectiles = 0, // Maximum number of projectiles in flight
                    MaxReloads = 0, // Maximum number of reloads in the LIFETIME of a weapon
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "", // Audio for warmup effect.
                    FiringSound = "K_NR_LaserCannon_Heavy", // Audio for firing.
                    FiringSoundPerShot = true, // Whether to replay the sound for each shot, or just loop over the entire track while firing.
                    ReloadSound = "", // Sound SubtypeID, for when your Weapon is in a reloading state
                    NoAmmoSound = "",
                    HardPointRotationSound = "WepTurretGatlingRotate", // Audio played when turret is moving.
                    BarrelRotationSound = "WepShipGatlingRotation",
                    FireSoundEndDelay = 120, // How long the firing audio should keep playing after firing stops. Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..).
                    FireSoundNoBurst = true, // Don't stop firing sound from looping when delaying after burst.
                },
                Graphics = new HardPointParticleDef
                {
                    Effect1 = new ParticleDef
                    {
                        Name = "", // SubtypeId of muzzle particle effect.
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 1), // Deprecated, set color in particle sbc.
                        Offset = Vector(x: 0, y: 0, z: 0), // Offsets the effect from the muzzle empty.
                        Extras = new ParticleOptionDef
                        {
                            Loop = false, // Set this to the same as in the particle sbc!
                            Restart = false, // Whether to end a looping effect instantly when firing stops.
                            Scale = 1f, // Scale of effect.
                        },
                    },
                    Effect2 = new ParticleDef
                    {
                        Name = "",
                        Color = Color(red: 0, green: 0, blue: 0, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),
                        Extras = new ParticleOptionDef
                        {
                            Loop = false, // Set this to the same as in the particle sbc!
                            Restart = false,
                            Scale = 1f,
                        },
                    },
                },
            },
            Ammos = new[] {
                Ammo_Me_Laser_Red,
                Ammo_Me_Laser_Green,
                Ammo_Me_Laser_Blue,
                Ammo_Me_Laser_Purple,
                Ammo_Me_Laser_Yellow, // Must list all primary, shrapnel, and pattern ammos.
            },
            Animations = NewRepublic_EWing_WingII_Animations,
            //Upgrades = UpgradeModules,
        };
        // Don't edit below this line.
    }
}
