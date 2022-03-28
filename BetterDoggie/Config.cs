// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDoggie
{
    using System.ComponentModel;
    using Exiled.API.Features;
    using Exiled.API.Interfaces;
    using UnityEngine;

    /// <inheritdoc />
    public class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the amnesia effect should be disabled.
        /// </summary>
        public bool DisableAmnesia { get; set; } = true;

        /// <summary>
        /// Gets or sets the speed boost Scp939 should receive.
        /// </summary>
        [Description("The speed boost Scp939 should receive. Set to 0 or less to disable.")]
        public byte SpeedBoost { get; set; } = 20;

        /// <summary>
        /// Gets or sets the duration the dog should get slowed down when attacking.
        /// </summary>
        [Description("The duration the dog should get slowed down when attacking.")]
        public float SlowdownDuration { get; set; } = 3f;

        /// <summary>
        /// Gets or sets a value indicating whether the slowdown time stacks for each attack the dog does.
        /// </summary>
        [Description("Whether the slowdown time stacks for each attack the dog does.")]
        public bool ShouldSlowdownStack { get; set; } = true;

        /// <summary>
        /// Gets or sets the size of the dog.
        /// </summary>
        [Description("The size of the dog.")]
        public Vector3 DoggieScale { get; set; } = new Vector3(.85f, .85f, .85f);

        /// <summary>
        /// Gets or sets the base amount of damage the dog will do.
        /// </summary>
        [Description("The base amount of damage the dog will do.")]
        public float BaseDamage { get; set; } = 40f;

        /// <summary>
        /// Gets or sets the maximum amount of additional damage the dog can deal.
        /// </summary>
        [Description("The maximum amount of additional damage the dog can deal.")]
        public float MaxDamageBoost { get; set; } = 150f;

        /// <summary>
        /// Gets or sets the message to send to players when they spawn as the dog.
        /// </summary>
        [Description("Message to send to players when they spawn as the dog.")]
        public Broadcast SpawnBroadcast { get; set; } = new Broadcast("<color=orange>You have spawned as an <color=red>upgraded</color> SCP-939! You run <color=red>faster</color> but slow down when you attack!", 8);
    }
}