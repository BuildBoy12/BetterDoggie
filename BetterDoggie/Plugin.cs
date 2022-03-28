// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDoggie
{
    using System;
    using Exiled.API.Features;
    using PlayerEvents = Exiled.Events.Handlers.Player;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <summary>
        /// Gets the only existing instance of the <see cref="Plugin"/> class.
        /// </summary>
        public static Plugin Instance { get; private set; }

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override Version Version => new Version(2, 0, 0);

        /// <inheritdoc />
        public override Version RequiredExiledVersion => new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            Instance = this;
            eventHandlers = new EventHandlers(this);
            PlayerEvents.ChangingRole += eventHandlers.OnChangingRole;
            PlayerEvents.ReceivingEffect += eventHandlers.OnReceivingEffect;

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            PlayerEvents.ChangingRole -= eventHandlers.OnChangingRole;
            PlayerEvents.ReceivingEffect -= eventHandlers.OnReceivingEffect;
            eventHandlers = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}