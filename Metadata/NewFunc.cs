using GTA;
using GTA.Native;

namespace Metadata
{
	public static class NewFunc
	{
		#region Global
		public static bool HideHud = false;

		static Hash Hash(ulong hash)
		{
			return (Hash)hash;
		}
		#endregion

		#region Retractable Wheels
		public static bool HasRetractableWheels(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_HAS_RETRACTABLE_WHEELS, vehicle);
		}

		public static void RaiseRetractableWheels(this Vehicle vehicle)
		{
			Function.Call(GTA.Native.Hash.SET_WHEELS_EXTENDED_INSTANTLY, vehicle);
		}

		public static void LowerRetractableWheels(this Vehicle vehicle)
		{
			Function.Call(GTA.Native.Hash.SET_WHEELS_RETRACTED_INSTANTLY, vehicle);
		}
		#endregion

		#region Rocket Boost
		public static bool HasRocketBoost(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_HAS_ROCKET_BOOST, vehicle.Handle);
		}

		public static bool IsRocketBoostActive(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.IS_ROCKET_BOOST_ACTIVE, vehicle);
		}

		public static void SetRocketBoostActive(this Vehicle vehicle, bool active)
		{
			Function.Call(GTA.Native.Hash.SET_ROCKET_BOOST_ACTIVE, vehicle, active);
		}

		public static void SetRocketBoostRefillTime(this Vehicle vehicle, float seconds)
		{
			Function.Call(GTA.Native.Hash.SET_SCRIPT_ROCKET_BOOST_RECHARGE_TIME, vehicle, seconds);
		}

		public static void SetRocketBoostPercentage(this Vehicle vehicle, float percentage)
		{
			Function.Call(GTA.Native.Hash.SET_ROCKET_BOOST_FILL, vehicle, percentage);
		}
		#endregion

		#region Nitro Boost
		public static void SetBoostActiveSound(this Vehicle vehicle, bool toggle)
		{
			Function.Call(GTA.Native.Hash.SET_VEHICLE_BOOST_ACTIVE, vehicle, toggle);
		}

		public static bool IsVehicleShuntBoostActive(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_IS_VEHICLE_SHUNTING, vehicle);
		}

		public static void SetNitroEnabled(this Vehicle vehicle, bool toggle, float level = 2.5f, float power = 1.1f, float rechargeTime = 4f, bool disableSound = false)
		{
			if (!Function.Call<bool>(GTA.Native.Hash.HAS_NAMED_PTFX_ASSET_LOADED, "veh_xs_vehicle_mods"))
				Function.Call(GTA.Native.Hash.REQUEST_NAMED_PTFX_ASSET, "veh_xs_vehicle_mods");

			if (toggle)
			{
				// if (!Function.Call<bool>(GTA.Native.Hash.ANIMPOSTFX_IS_RUNNING, "CrossLine"))
					// Function.Call(GTA.Native.Hash.ANIMPOSTFX_PLAY, "CrossLine", 0, true);
				Function.Call(GTA.Native.Hash.SET_OVERRIDE_NITROUS_LEVEL, vehicle, toggle, level, power, rechargeTime, disableSound);
			} 
			else
			{
				// if (Function.Call<bool>(GTA.Native.Hash.ANIMPOSTFX_IS_RUNNING, "CrossLine"))
					// Function.Call(GTA.Native.Hash.ANIMPOSTFX_PLAY, "CrossLine");
				Function.Call(GTA.Native.Hash.SET_OVERRIDE_NITROUS_LEVEL, vehicle, toggle, level, power, rechargeTime, disableSound);
			}
		}

		public static void SetNitroHudActive(bool toggle)
		{
			if (toggle)
			{
				Function.Call(GTA.Native.Hash.SET_PLAYER_IS_IN_DIRECTOR_MODE, true);
				Function.Call(GTA.Native.Hash.SET_ABILITY_BAR_VISIBILITY, toggle);
			}
			else
			{
				Function.Call(GTA.Native.Hash.SET_PLAYER_IS_IN_DIRECTOR_MODE, false);
			}
		}
		#endregion

		#region Xenon Lights Color
		public static void XenonLightsColor(this Vehicle vehicle, eXenonColor colorIndex)
		{
			Function.Call(GTA.Native.Hash.SET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle, (int)colorIndex);
		}

		public static eXenonColor XenonLightsColor(this Vehicle vehicle)
		{
			return Function.Call<eXenonColor>(GTA.Native.Hash.GET_VEHICLE_XENON_LIGHT_COLOR_INDEX, vehicle);
		}

		public enum eXenonColor
		{
			White = 0,
			Blue = 1,
			ElectricBlue = 2,
			MintGreen = 3,
			Limegreen = 4,
			Yellow = 5,
			GoldenShower = 6,
			Orange = 7,
			Red = 8,
			PonyPink = 9,
			HotPink = 10,
			Blacklight = 11,
			Purple = 12
		}
		#endregion

		#region Dominator Tombstone 
		public static bool IsVehicleHaveTombstone(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_DOES_VEHICLE_HAVE_TOMBSTONE, vehicle);
		}

		public static void HideTombstone(this Vehicle vehicle, bool toggle)
		{
			Function.Call(GTA.Native.Hash.HIDE_TOMBSTONE, vehicle, toggle);
		}
		#endregion

		#region Deluxo Flight
		public static void SetSpecialFlightWingRatio(this Vehicle vehicle, float ratio)
		{
			Function.Call(GTA.Native.Hash.SET_HOVER_MODE_WING_RATIO, vehicle, ratio);
		}

		public static void SetHoverTransformRatio(this Vehicle vehicle, float ratio)
		{
			Function.Call(GTA.Native.Hash.SET_SPECIAL_FLIGHT_MODE_RATIO, vehicle, ratio);
		}

		public static void SetHoverTransformPercentage(this Vehicle vehicle, float percent)
		{
			Function.Call(GTA.Native.Hash.SET_SPECIAL_FLIGHT_MODE_TARGET_RATIO, vehicle, percent);
		}

		public static bool CanTransformFlightMode(this Vehicle vehicle)
		{
			return vehicle.Bones.Contains("thrust");
		}

		public static void SetHoverTransformActive(this Vehicle vehicle, bool toggle)
		{
			Function.Call(GTA.Native.Hash.SET_DISABLE_HOVER_MODE_FLIGHT, vehicle, toggle);
		}
		#endregion

		#region Car to Submarine
		public static void TransformVehicleToSubmarine(this Vehicle vehicle, bool noAnimation)
		{
			Function.Call(GTA.Native.Hash.TRANSFORM_TO_SUBMARINE, vehicle, noAnimation);
		}

		public static void TransformSubmarineToVehicle(this Vehicle vehicle, bool noAnimation)
		{
			Function.Call(GTA.Native.Hash.TRANSFORM_TO_CAR, vehicle, noAnimation);
		}

		public static bool IsSubmarineVehicleTransformed(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.IS_VEHICLE_IN_SUBMARINE_MODE, vehicle);
		}

		public static bool CanTransformSubmarineMode(this Vehicle vehicle)
		{
			return vehicle.Bones.Contains("turbine_hatch");
		}
		#endregion

		#region Amphibious Vehicle
		public static bool IsModelAnAmphibiousCar(this Model model)
		{
			return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_AN_AMPHIBIOUS_CAR, model);
		}

		public static bool IsModelAnAmphibiousQuadBike(this Model model)
		{
			return Function.Call<bool>(GTA.Native.Hash.IS_THIS_MODEL_AN_AMPHIBIOUS_QUADBIKE, model);
		}
		#endregion

		#region Parachute & Jump
		public static bool CanJump(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_CAR_HAS_JUMP, vehicle);
		}

		public static void SetParachuteModel(this Vehicle vehicle, int modelhash)
		{
			// parachute model = 230075693
			Function.Call(GTA.Native.Hash.VEHICLE_SET_PARACHUTE_MODEL_OVERRIDE, vehicle, modelhash);
		}

		public static void SetParachuteTextVariation(this Vehicle vehicle, eTextureVariation textureVariation)
		{
			Function.Call(GTA.Native.Hash.VEHICLE_SET_PARACHUTE_MODEL_TINT_INDEX, vehicle, (int)textureVariation);
		}

		public enum eTextureVariation
		{
			Unk0 = 0,
			Unk1 = 1,
			Unk2 = 2,
			Unk3 = 3,
			Unk4 = 4,
			Unk5 = 5,
			Unk6 = 6,
			Unk7 = 7
		}

		public static bool HasParachute(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_VEHICLE_HAS_PARACHUTE, vehicle);
		}

		public static bool CanActivateParachute(this Vehicle vehicle)
		{
			return Function.Call<bool>(GTA.Native.Hash.GET_VEHICLE_CAN_DEPLOY_PARACHUTE, vehicle);
		}

		public static void SetParachuteActive(this Vehicle vehicle, bool active)
		{
			Function.Call(GTA.Native.Hash.VEHICLE_START_PARACHUTING, vehicle, active);
		}
		#endregion

		#region Others
		public static Vehicle GetLastRammedVehicle(this Vehicle vehicle)
		{
			return Function.Call<Vehicle>(GTA.Native.Hash.GET_LAST_SHUNT_VEHICLE, vehicle);
		}

		public static int GetNumberOfVehicleDoors(this Vehicle vehicle)
		{
			return Function.Call<int>(GTA.Native.Hash.GET_NUMBER_OF_VEHICLE_DOORS, vehicle);
		}

		public static bool HasRam(this Vehicle vehicle)
		{
			return vehicle.Bones.Contains("ram_1mod");
		}

		public static bool HasScoop(this Vehicle vehicle)
		{
			return vehicle.Bones.Contains("scoop_1mod");
		}

		public static bool HasSpike(this Vehicle vehicle)
		{
			return vehicle.Bones.Contains("spike_1mod");
		}

		public static bool IsCheating(string cheat)
		{
			return Function.Call<bool>(GTA.Native.Hash.HAS_PC_CHEAT_WITH_HASH_BEEN_ACTIVATED, Game.GenerateHash(cheat));
		}
		#endregion
	}
}
