namespace FillingTheTank

open System.Collections.Generic
open FillingTheTank.Gas

type Mixture(parameters: MixtureParameters, initialParams: InitialParameters) =
    member x.Calculate(mixture: IDictionary<GasElementName, GasElementParams>) =

        for i in mixture do
            parameters.MolarMassOfTheMixture <-
                parameters.MolarMassOfTheMixture + (i.Value.MolarFraction * i.Value.MolarMass)
                
            parameters.CriticalPressureOfTheMixture <-
                parameters.CriticalPressureOfTheMixture + (i.Value.MolarFraction * i.Value.CriticalPressure)

            parameters.CriticalTemperatureOfTheMixture <-
                parameters.CriticalTemperatureOfTheMixture + (i.Value.MolarFraction * i.Value.CriticalTemperature)

        parameters.GasConstantOfTheMixture <- initialParams.GasConstant / parameters.MolarMassOfTheMixture

        let pressureConverted = parameters.CriticalPressureOfTheMixture * 100000.

        parameters.ParameterA <-
            0.42748 * pown parameters.GasConstantOfTheMixture 2 * parameters.CriticalTemperatureOfTheMixture ** 2.5
            / pressureConverted

        parameters.ParameterB <-
            0.08664 * parameters.GasConstantOfTheMixture * parameters.CriticalTemperatureOfTheMixture
            / pressureConverted

        parameters.CriticalBetta <-
            2. / (initialParams.AdiabaticIndex + 1.)
            ** (initialParams.AdiabaticIndex / (initialParams.AdiabaticIndex - 1.))
