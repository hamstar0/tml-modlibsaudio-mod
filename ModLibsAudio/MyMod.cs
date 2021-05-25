using System;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace ModLibsAudio {
	/// @private
	partial class ModLibsAudioMod : Mod {
		public static ModLibsAudioMod Instance { get; private set; }



		////////////////

		public override void Load() {
			ModLibsAudioMod.Instance = this;
		}

		////

		public override void Unload() {
			try {
				LogLibraries.Alert( "Unloading mod..." );
			} catch { }

			ModLibsAudioMod.Instance = null;
		}
	}
}
