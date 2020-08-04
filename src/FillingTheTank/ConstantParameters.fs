namespace FillingTheTank

open System.Collections.Generic
open FillingTheTank.Gas

type Mixture(parameters: MixtureParameters, initialParams: InitialParameters) =
    member x.Calculate() =

        let mixture =
            [ GasElementName.Methane, GasElementParams(0.981848, 16.043, 42.26, 190.66)
              GasElementName.Ethane, GasElementParams(0.006848, 30.070, 48.71, 305.33)
              GasElementName.Propane, GasElementParams(0.002057, 44.097, 42.55, 369.90)
              GasElementName.Isobutane, GasElementParams(0.000353, 58.124, 38.01, 407.15)
              GasElementName.Nbutane, GasElementParams(0.000333, 58.124, 36.50, 425.95)
              GasElementName.Npentane, GasElementParams(0.000046, 72.151, 33.73, 469.50)
              GasElementName.CarbonDioxide, GasElementParams(0.000339, 44.009, 73.83, 304.26)
              GasElementName.Nitrogen, GasElementParams(0.008176, 28.014, 33.94, 126.25) ]
            |> dict

        for i in mixture do
            parameters.MolarMassOfTheMixture <-
                parameters.MolarMassOfTheMixture + (i.Value.MolarFraction * i.Value.MolarMass)

            parameters.CriticalPressureOfTheMixture <-
                parameters.CriticalPressureOfTheMixture + (i.Value.MolarFraction * i.Value.CriticalPressure)

            parameters.CriticalTemperatureOfTheMixture <-
                parameters.CriticalTemperatureOfTheMixture + (i.Value.MolarFraction * i.Value.CriticalTemperature)
                
                
        parameters.GasConstantOfTheMixture <-  initialParams.GasConstant / parameters.MolarMassOfTheMixture


        ()
