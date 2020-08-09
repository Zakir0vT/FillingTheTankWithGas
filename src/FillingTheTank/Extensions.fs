namespace FillingTheTank

open FillingTheTank.DichotomyMethod
open FillingTheTank.GasParameters
open FillingTheTank.MixtureParameters
open Ninject
open RungeKutta

[<AutoOpen>]
module NinjectExtension =
    type StandardKernel with
        member x.ConfigureContainer (kernel: StandardKernel) = 
            kernel.Bind<InitialParameters>().ToSelf().InTransientScope() |> ignore
            kernel.Bind<MixtureParameters>().ToSelf().InSingletonScope |> ignore
            kernel.Bind<Mixture>().ToSelf().InSingletonScope |> ignore
            kernel.Bind<RK6>().ToSelf().InTransientScope |> ignore
            kernel.Bind<Density>().ToSelf().InTransientScope |> ignore
