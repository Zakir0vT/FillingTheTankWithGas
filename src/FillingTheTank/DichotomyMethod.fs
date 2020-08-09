namespace FillingTheTank

open FillingTheTank.GasParameters

module DichotomyMethod =
    type Density(parameters: MixtureParameters) =
        member x.Calculate(ro1, ro2, p, t) =

            let eps = 0.000001
            let mutable ro1 = ro1
            let mutable ro2 = ro2
            let mutable ro3 = 0.

            let equation ro p t =
                let ro = 1. / ro
                let formula =
                    parameters.GasConstantOfTheMixture * t / (ro - parameters.ParameterB)
                    - (parameters.ParameterA / (ro * (ro + parameters.ParameterB))) * (t ** 0.5) - p
                formula

            let dichotomyLogic =
                ro3 <- (ro1 + ro2) / 2.
                if (equation ro1 p t) * (equation ro3 p t) < 0. then ro2 <- ro3
                else ro1 <- ro3

            let condition = (equation ro3 p t |> abs) >= eps
            while condition do
                dichotomyLogic

            ro3
