using ParkingLotManagement.Model.Enums;
using ParkingLotManagement.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLotManagement.Factory
{
    internal class ParkingSpotAssignmentFactory
    {
        public static ISpotAssignmentStrategy GetSpotAssignmentStrategy(SpotAssignmentStrategyType strategyType)
        {
            switch (strategyType)
            {
                case SpotAssignmentStrategyType.Manual:
                    return new ManualSpotAssignmentStrategy();
                case SpotAssignmentStrategyType.Random:
                    return new RandomSpotAssignmentStrategy();
                case SpotAssignmentStrategyType.Assign_First_Empty:
                    return new AssignFirstEmptySpotStrategy();
                default:
                    throw new ArgumentException($"Invalid strategy type: {strategyType}");
            }
        }
    }
}
