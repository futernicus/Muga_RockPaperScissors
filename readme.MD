# RockPaperScissors
An implementation of Rock, Paper, Scissors written In ASP.NET MVC

Minimal implementation developed for a technical test

# Building
This is a Microsoft dotnet solution implemented in C# targeting dotnet framework V4.5.2

It was developed in Microsoft Visual Studio 2015.

## Computer strategy
The computer strategy is to select one of ( rock, paper, scissors ) at random

A less naive strategy would look at frequency analysis of typical players

e.g. perhaps Rock is a more frequent choice than paper, even for a random new player

Also when playing the same person the stategy could look for patterns in behaviour

i.e. the computer could learn about how this player plays

## Architecture


The UI is provided by a MVC website.

The game logic is in class library RockPaperScissorsEngine. 

This has a set of supporting unit tests.

Some minor changes could be done to make the markup more semantic, and use more HTML5 structure elements.

The use of Bootstrap could be reconsidered if needed.

### RockPaperScissorsEngine
The RockPaperScissorsEngine class library can be plugged into any dotnet application

Create two players objects, these should implement the RockPaperScissorsEngine.IPlayer interface

The concrete class should be RockPaperScissorsEngine.HumanPlayer or RockPaperScissorsEngine.ComputerPlayer

Create a RockPaperScissorsEngine.Game class which implements RockPaperScissorsEngine.IGame

The constructor takes two IPlayers ( you must specify at least one of these as a ComputerPlayer)

### RockPaperScissorsEngineTest
This is a set of unit tests for RockPaperScissorsEngine

### RockPaperScissors
This is a MVC application which uses the RockPaperScissorsEngine to allow playing