// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

module HandHistory

type Player = {
    Name:string
}

type StatType = AmountPutInPot=0 | AmountVoluntarilyPutIntoPot=1 | VoluntarilyPutIntoPot=2

type HandActionType = BigBlind=0 | SmallBlind=1 | Raise=2 | Call=3 | Bet=4 | Check=5 | Fold=6 | UncalledBet=7 | Show=8 | Wins=9

type Street = Preflop=1 | Flop=2 | Turn=3 | River=4 | Showdown=5

type HandAction = {
    Player:Player; 
    Action:HandActionType; 
    Amount:decimal;
}

type HandHistory = {
    Players:Player list;
    HandActions:HandAction list
}
//
//type VoluntarilyPutInPotStat = {
//    Player:Player;
//    Street:Street;
//    VoluntarilyPutInPotCount:int;
//}

open System

[<EntryPoint>]
let main argv = 
    
    printfn "%A" argv
    let ekologe = {Name="ekologe"}
    let panter555 = {Name="PANTER555"}
    let kassir8485 = {Name="KASSIR8485"}
    let guolig = {Name="GuOlIg"}
    let martin070 = {Name="martin070"}
    let jammydodger7 = {Name="jammyd0dger7"}

    let actions = [
        {Player= ekologe; Action= HandActionType.SmallBlind; Amount= -0.5M;}
        {Player= panter555; Action= HandActionType.BigBlind; Amount= -1M;}
        {Player= kassir8485; Action= HandActionType.Call; Amount= -1M;}
        {Player= guolig; Action= HandActionType.Fold; Amount= 0M;}
        {Player= martin070; Action= HandActionType.Call; Amount= -1M;}
        {Player= jammydodger7; Action= HandActionType.Fold; Amount= 0M;}
        {Player= ekologe; Action= HandActionType.Raise; Amount= -19.5M;}
        {Player= panter555; Action= HandActionType.Call; Amount= -17.74M;}
        {Player= kassir8485; Action= HandActionType.Fold; Amount= -0M;}
        {Player= martin070; Action= HandActionType.Fold; Amount= -0M;}
        {Player= ekologe; Action= HandActionType.UncalledBet; Amount= 1.26M;}
        {Player= ekologe; Action= HandActionType.Show; Amount= 0M;}
        {Player= panter555; Action= HandActionType.Show; Amount= 0M;}
        {Player= ekologe; Action= HandActionType.Wins; Amount= 37.7M;}
    ]

    let isVpipHandAction action = match action.Action with | HandActionType.Bet | HandActionType.Call | HandActionType.Raise -> true | _ -> false

    let calcAmountPutInPotForActions actions =
        actions |> List.sumBy (fun a -> a.Amount)
        
    let sumAmountsFromActions actions = 
        actions |> Seq.map(fun a -> a.Amount) |> Seq.reduce(fun acc elem -> acc + elem)

    let calcAmountPutInPotForPlayers (actions) = 
        actions |> Seq.groupBy (fun a -> a.Player.Name)
                |> Seq.map(fun (key,values) -> (key, sumAmountsFromActions(values)))

    let calculateFlagStat (actions, checkcondition) = match actions|> Seq.exists(checkcondition) with | true -> 1 | false -> 0

    let calculateDecimalSumStat (action:'a, checkCondition, valSelector:HandAction->decimal) = actions |> Seq.where(checkCondition) |> Seq.map(valSelector) |> Seq.sum

    let data = calcAmountPutInPotForPlayers(actions)
    let data2 = actions |> calcAmountPutInPotForPlayers
    
    let data3 = calcAmountPutInPotForPlayers(actions |> Seq.filter(fun a -> isVpipHandAction(a)))
    
    printfn "%A" data
    Console.ReadLine() |> ignore
    0 // return an integer exit code
