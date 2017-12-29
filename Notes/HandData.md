# Hand Data Storage Ideas

## Data To Extract
* Final Board State
* Hole Cards
* Bet/Call/Check/Fold Info
* TotalWon/Lost (All Players)
 
### Check/Call/Raise/Fold Info
##### Terms and Denotation
Consider a ***Round*** of play, immediately following the deal, to start with the player to the left of the small blind. The round completes when the small blind has made their decision. If the small blind is no longer in the game (they have folded), the round completes with the last player before the small blind to take an action.

Consider a ***Decision*** to be a combination of a dollar amount (optional) and a decision (Check/Call/Raise/Fold). A ***Decision*** will be represented, in this document, as a text string followed by an amount of money placed into the pot, in parentheses (optional). Examples:
* `Check` - the player checks
* `Call ($0.05)` - the player calls, placing $.05 into the pot
* `Call` - the player calls, placing no money in the pot (perhaps they are the big blind and everyone checked)
* `Raise ($1.50)` - the player raises, placing $1.50 into the pot
* `Fold` - the player folds
* `BigBlind ($0.50)` - the player contributes $0.50 to the pot because they are the big blind
* `SmallBlind ($0.25)` - the player contributes $0.25 to the pot because they are the small blind
 
A collection of this information could be called ***Action***. All of the action in a hand could be bucketed into one of several categories: *Preflop*, *Flop*, *Turn*, *River*
 
##### Potential Data Structure
It may be useful to represent the data in a kind of table, one column per ***Player***, one row per ***Round***. Each cell containing the ***Action***.

It would allow us to maintain complete info about what happened at each stage of the hand and perhaps provide useful features like being able to calculate a ***Player***'s contribution to the pot by summing up the dollar amounts in his column. For example:


|Phase    |Robert       |Jack |Keith        |Todd              |Don             |Pot Total|
|---------|-------------|-----|-------------|------------------|----------------|---------|
|Preflop  |Call ($0.50) |Fold |Raise ($0.75)|SmallBlind ($0.25)|BigBlind ($0.50)|$2.00    |
|Preflop  |*EOR*        |*Out*|Check        |Fold              |Call ($0.25)    |$2.25    |
|**Total**|$0.50        |$0.00|$0.75        |$0.25             |$0.75           |$2.25    |
|Flop     |Check        |Check|Bet ($0.25)  |*Out*             |Check           |$2.75    |
|Flop     |Check        |Check|Bet ($0.25)  |*Out*             |Check           |$2.75    |
