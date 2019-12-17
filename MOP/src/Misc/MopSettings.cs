﻿namespace MOP
{
    class MopSettings
    {
        public static bool IsModActive { get; set; }

        public static int ActiveDistance { get; set; }
        public static float ActiveDistanceMultiplicationValue { get; set; }
        
        public static bool SafeMode { get; set; }
        public static bool ToggleVehicles { get; set; }
        public static bool ToggleItems { get; set; }

        public static int TrafficLimit { get; set; }

        public static bool EnableObjectOcclusion { get; set; }
        public static int OcclusionSamples = 120;
        public static int ViewDistance = 400;
        public static int OcclusionSampleDelay = 1;
        public static int OcclusionHideDelay = -1;
        public static int MinOcclusionDistance = 50;
        public static int OcclusionMethod = 1;

        public static void UpdateValues()
        {
            ActiveDistance = int.Parse(MOP.activeDistance.GetValue().ToString());
            ActiveDistanceMultiplicationValue = GetActiveDistanceMultiplicationValue();
            
            SafeMode = (bool)MOP.safeMode.GetValue();
            ToggleVehicles = (bool)MOP.toggleVehicles.GetValue();
            ToggleItems = (bool)MOP.toggleItems.GetValue();

            TrafficLimit = GetVehicleLimit();
            MSCLoader.ModConsole.Print(TrafficLimit);

            EnableObjectOcclusion = (bool)MOP.enableObjectOcclusion.GetValue();
            OcclusionSamples = GetOcclusionSamples();
            ViewDistance = int.Parse(MOP.occlusionDistance.GetValue().ToString());
            OcclusionSampleDelay = int.Parse(MOP.occlusionSampleDelay.GetValue().ToString());
            MinOcclusionDistance = int.Parse(MOP.minOcclusionDistance.GetValue().ToString());

            OcclusionMethod = GetOcclusionMethod();
        }

        static float GetActiveDistanceMultiplicationValue()
        {
            switch (ActiveDistance)
            {
                default:
                    return 1;
                case 0:
                    return 0.5f;
                case 2:
                    return 2;
                case 3:
                    return 4;
            }
        }

        static int GetOcclusionMethod()
        {
            if ((bool)MOP.occlusionNormal.GetValue())
                return 0;

            if ((bool)MOP.occlusionChequered.GetValue())
                return 1;

            if ((bool)MOP.occlusionDouble.GetValue())
                return 2;

            return 1;
        }

        static int GetOcclusionSamples()
        {
            if ((bool)MOP.occlusionSamplesLowest.GetValue())
                return 10;

            if ((bool)MOP.occlusionSamplesLower.GetValue())
                return 30;

            if ((bool)MOP.occlusionSamplesLow.GetValue())
                return 60;

            if ((bool)MOP.occlusionSamplesDetailed.GetValue())
                return 120;

            if ((bool)MOP.occlusionSamplesVeryDetailed.GetValue())
                return 240;

            return 120;
        }

        static int GetVehicleLimit()
        {
            if ((bool)MOP.highwayTrafficDensityAll.GetValue())
                return -1;

            if ((bool)MOP.highwayTrafficDensityMost.GetValue())
                return 7;

            if ((bool)MOP.highwayTrafficDensityHalf.GetValue())
                return 5;

            if ((bool)MOP.highwayTrafficDensityQuarter.GetValue())
                return 3;

            return -1;
        }
    }
}
