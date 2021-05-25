﻿using System;
using Microsoft.Xna.Framework.Audio;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Libraries.Debug;


namespace ModLibsAudio.Services.OverlaySounds {
	/// <summary>
	/// Provides a way to create ambient sound effects that overlay existing game sounds and music.
	/// </summary>
	public partial class OverlaySound {
		/// <summary>
		/// </summary>
		/// <returns></returns>
		public delegate (float VolumeOverride, float PanOverride, float PitchOverride, bool IsEnded) SoundLooper();




		/// <summary>Creates an OverlaySound instance. Does not auto play.</summary>
		/// <param name="sourceMod"></param>
		/// <param name="soundPath"></param>
		/// <param name="fadeTicks"></param>
		/// <param name="playDurationTicks">If -1, sound repeats until `customCondition` says otherwise.</param>
		/// <param name="customCondition">Returns a volume scale float and a boolean to indicate if the sound has ended.</param>
		/// <returns></returns>
		public static OverlaySound Create(
					Mod sourceMod,
					string soundPath,
					int fadeTicks,
					int playDurationTicks=-1,
					SoundLooper customCondition =null ) {
			return new OverlaySound( sourceMod, soundPath, fadeTicks, playDurationTicks, customCondition );
		}



		////////////////

		private Mod SourceMod;
		private string SoundPath;
		private SoundEffectInstance MyInstance = null;

		private int ElapsedTicks = 0;
		private int ElapsedFadeTicks = 0;

		private int MaxPlayDurationTicks;
		private int FadeTicks;

		private SoundLooper CustomCondition = null;


		////////////////

		/// <summary></summary>
		public bool IsFadingOut { get; private set; } = false;

		/// <summary></summary>
		public bool IsEndlessLoop => this.MaxPlayDurationTicks < 0;



		////////////////

		internal OverlaySound(
				Mod sourceMod,
				string soundPath,
				int fadeTicks,
				int playDurationTicks,
				SoundLooper customCondition ) {
			this.SourceMod = sourceMod;
			this.SoundPath = soundPath;
			this.FadeTicks = fadeTicks <= 1 ? -1 : fadeTicks;
			this.MaxPlayDurationTicks = playDurationTicks;
			this.CustomCondition = customCondition;
		}
	}
}
