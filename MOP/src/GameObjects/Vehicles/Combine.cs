﻿// Modern Optimization Plugin
// Copyright(C) 2019-2020 Athlon

// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with this program.If not, see<http://www.gnu.org/licenses/>.

namespace MOP
{
    class Combine : Vehicle
    {
        public Combine(string gameObjectName) : base(gameObjectName)
        {
            Toggle = ToggleCombineActive;

            // Ignore Rule
            IgnoreRule vehicleRule = Rules.instance.IgnoreRules.Find(v => v.ObjectName == this.gameObject.name);
            if (vehicleRule != null)
            {
                Toggle = IgnoreToggle;

                if (vehicleRule.TotalIgnore)
                    IsActive = false;
            }
        }

        public void ToggleCombineActive(bool enabled)
        {
            // If combine harvester is not available yet, simply ignore it.
            if (!MopFsmManager.IsCombineAvailable())
                return;

            // Use normal toggling script.
            this.ToggleActive(enabled);
        }
    }
}
