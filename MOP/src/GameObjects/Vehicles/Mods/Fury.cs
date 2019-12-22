﻿using UnityEngine;
using System.Linq;

namespace MOP
{
    class Fury : Vehicle
    {
        // Fury class - made by Konrad "Athlon" Figura
        // 
        // Adds support for disabling and enabling car from Drivable Fury mod.

        /// <summary>
        /// Initialize class
        /// </summary>
        /// <param name="gameObject"></param>
        public Fury(string gameObject) : base(gameObject)
        {
            furyScript = this;
        }

        /// <summary>
        /// Enable or disable car
        /// </summary>
        public new void ToggleActive(bool enabled)
        {
            // Don't run the code, if the value is the same
            if (gm == null || carDynamics.enabled == enabled) return;

            carDynamics.enabled = enabled;
            axles.enabled = enabled;
            rb.isKinematic = !enabled;
        } 
    }
}