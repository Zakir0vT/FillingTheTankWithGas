namespace FillingTheTank

open FillingTheTank.GasParameters
open FillingTheTank.MixtureParameters
open Ninject

[<AutoOpen>]
module NinjectExtension =
    type StandardKernel with
        member x.ConfigureContainer (kernel: StandardKernel) = 
            kernel.Bind<InitialParameters>().ToSelf().InTransientScope() |> ignore
            kernel.Bind<MixtureParameters>().ToSelf().InSingletonScope |> ignore
            kernel.Bind<Mixture>().ToSelf().InSingletonScope |> ignore
