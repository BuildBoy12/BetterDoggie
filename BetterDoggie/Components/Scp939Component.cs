// -----------------------------------------------------------------------
// <copyright file="Scp939Component.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace BetterDoggie.Components
{
    using CustomPlayerEffects;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using UnityEngine;

    /// <inheritdoc />
    public class Scp939Component : MonoBehaviour
    {
        private Player player;
        private Config config;

        private MovementBoost movementBoost;
        private SinkHole sinkHole;

        private void Awake()
        {
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
            player = Player.Get(gameObject);
            config = Plugin.Instance.Config;
            movementBoost = player.ReferenceHub.playerEffectsController.GetEffect<MovementBoost>();
            sinkHole = player.ReferenceHub.playerEffectsController.GetEffect<SinkHole>();
        }

        private void Start()
        {
            player.Scale = config.DoggieScale;
            player.Broadcast(config.SpawnBroadcast);
        }

        private void OnDestroy()
        {
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
            if (player == null)
                return;

            player.Scale = Vector3.one;
            movementBoost.IsEnabled = false;
            sinkHole.IsEnabled = false;
        }

        private void Update()
        {
            if (player == null || !player.Role.Type.Is939())
            {
                Destroy(this);
                return;
            }

            if (!movementBoost.IsEnabled && !sinkHole.IsEnabled && config.SpeedBoost > 0)
            {
                player.EnableEffect<MovementBoost>();
                movementBoost.Intensity = config.SpeedBoost;
            }
        }

        private void OnHurting(HurtingEventArgs ev)
        {
            if (ev.Attacker == null || ev.Target == null || ev.Attacker == ev.Target || !ev.Attacker.Role.Type.Is939())
                return;

            ev.Amount = config.BaseDamage + (Mathf.Abs(ev.Attacker.ArtificialHealth - player.MaxArtificialHealth) / (player.MaxArtificialHealth * config.MaxDamageBoost));
            ev.Attacker.EnableEffect<SinkHole>(config.SlowdownDuration, config.ShouldSlowdownStack);
            ev.Attacker.ChangeEffectIntensity<SinkHole>(2);
        }
    }
}