using ParkingLotManagement.Model.Enums;
using System;

namespace ParkingLotManagement.Factory
{
    internal static class FeeCalculationStrategyFactory
    {
        public static Strategy.IFeeCalculationStrategy GetFeeCalculationStrategy(FeeCalculatorStrategyType type)
        {
            switch (type)
            {
                case FeeCalculatorStrategyType.Static:
                    return new Strategy.StaticFeeCalculationStrategy();
                case FeeCalculatorStrategyType.Dynamic:
                    return new Strategy.DynamicFeeCalculationStrategy();
                default:
                    throw new ArgumentException("Unsupported Fee Calculator Strategy Type");
            }
        }
    }
}
