
namespace FillingTheTank

//Природный газ близкий по составу к смеси "Северный поток"
module GasParameters =
    //Параметры элемента газа
    [<Struct>]
    type GasElementParams(molarFraction: float, molarMass: float, criticalPressure: float, criticalTemperature: float) =
        //Молярная доля
        member x.MolarFraction: float = molarFraction
        
        //Молярная масса
        member x.MolarMass: float = molarMass
        
        //Критическое давление
        member x.CriticalPressure: float = criticalPressure
        
        //Критическая температура 
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
        
    //Начальные параметры
    type InitialParameters()  =
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
        
        //Давление втекающего газа, Па
        member x.GasConstant  = 8314.4598
        
    //Параметры газовой смеси
    type MixtureParameters() =
        //Молярная масса смеси
        member val MolarMassOfTheMixture = 0. with get, set
        
        //Газовая постоянная смеси
        member val GasConstantOfTheMixture = 0. with get, set
        
        //Давление критическое смеси
        member val CriticalPressureOfTheMixture = 0. with get, set
        
        //Температура критическая смеси
        member val CriticalTemperatureOfTheMixture = 0. with get, set
        
        //Параметры a и b для уравнения Редлиха-Квонга
        member val ParameterA = 0. with get, set
        member val ParameterB = 0. with get, set
        
        //Параметр бетта критическая        
        member val CriticalBetta = 0. with get, set
        
