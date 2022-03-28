// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDoggie
{
    using BetterDoggie.Components;
    using CustomPlayerEffects;
    using Exiled.Events.EventArgs;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnChangingRole(ChangingRoleEventArgs)"/>
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (!ev.NewRole.Is939())
                return;

            if (ev.Player.GameObject.TryGetComponent(out Scp939Component scp939Component))
                UnityEngine.Object.Destroy(scp939Component);

            ev.Player.GameObject.AddComponent<Scp939Component>();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Player.OnReceivingEffect(ReceivingEffectEventArgs)"/>
        public void OnReceivingEffect(ReceivingEffectEventArgs ev)
        {
            if (plugin.Config.DisableAmnesia && ev.Effect is Amnesia)
                ev.IsAllowed = false;
        }
    }
}