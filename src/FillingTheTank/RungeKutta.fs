namespace FillingTheTank

open System
open System.Collections.Generic

module RungeKutta =
    type RK6 =
        member x.Calculate(t0, tk, dt, init_ro, init_t, f: Func<float, float * float, float * float>) =

            let mutable currentRo = init_ro
            let mutable currentT = init_t

            let lst = List<float * float>()
            lst.Add(init_ro, init_t)

            let time = t0 + dt / 2.
            let roFormula k = currentRo + k * dt / 2.
            let tFormula k = currentT + k * dt / 2.

            let mutable i = 1.
            while i <= tk / dt do
                let k1 = f.Invoke(t0, (currentRo, currentT))
                let k2 = f.Invoke(time, (roFormula (fst k1), tFormula (snd k1)))
                let k3 = f.Invoke(time, (roFormula (fst k2), tFormula (snd k2)))
                let k4 = f.Invoke(time, (roFormula (fst k3), tFormula (snd k3)))
                let k5 = f.Invoke(time, (roFormula (fst k4), tFormula (snd k4)))
                let k6 = f.Invoke(t0 + dt, (currentRo + (fst k5) * dt, currentT + (snd k5) * dt))

                let ks i = dt / 10. * (i k1 + 2. * i k2 + 2. * i k3 + 2. * i k4 + 2. * i k5 + i k6)
                currentRo <- currentRo + ks fst
                currentRo <- currentT + ks snd

                lst.Add(currentRo, currentT)

                i <- i + 1.

            lst
