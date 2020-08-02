namespace FillingTheTank

//Природный газ близкий по составу к смеси "Северный поток"
module Gas =
    //Параметры элемента газа
    [<Struct>]
    type GasElementParams(molarFraction: float, molarMass: float, criticalPressure: float, criticalTemperature: float) =
        member x.MolarFraction: float = molarFraction
        member x.MolarMass: float = molarMass
        member x.CriticalPressure: float = criticalPressure
        member x.CriticalTemperature: float = criticalTemperature

    //Состав газа
    type GasElementName =
        | Methane
        | Ethane
        | Propane
        | Isobutane
        | Nbutane
        | Npentane
        | CarbonDioxide
        | Nitrogen
        
    //Параметры газа
    type InitialParameters  =
        //Изохорная теплоемкость газа, Дж/(кг · К)
        member x.IsochoricHeatCapacity = 1750.
        
        //Коэффициент расхода
        member x.DepletionRate = 0.9
        
        //Коэффициент теплопередачи, Вт/(м2 · К)
        member x.HeatTransferCoefficient = 6.
        
        //Показатель адиабаты
        member x.AdiabaticIndex  = 1.3
        
        //Объем резервуара, м3
        member x.V  = 22.872
        
        //Площадь отверстия сопла, м2
        member x.F  = 0.00785
        
        //Площадь боковой поверхности емкости, м2
        member x.S  = 240.
        
        //Начальная температура в сосуде, К
        member x.T0  = 253.
        
        //Температура втекающего газа, К
        member x.T1  = 293.
        
        //Начальное давление в сосуде, Па
        member x.P0  = 200000.
        
        //Давление втекающего газа, Па
        member x.P1  = 25000000.
