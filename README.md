# About
This app is my first ever project posted on github. And first ever project that I can call complete. It i not intended to be used live.
Firstly, there already is some websites that serve the purpose of this app, but also, if I wanted it to be used live, there would be no need to make the app as complex as it is.

I chose Blazor Webassembly for this app because I was mostly comfortable with C#. I'm a undergrad and it's my first "serious" programming language. I've known some html/css/javascript and SQL from before too, but not much.

The app pulls data from an SQL Server using Entity Framework and via Web API.

Javascript is used for the simulator page UX. The design is based on the actual game's (Naruto Online) UI. The images are all from the game too, obviously.

Please bear with the front end code, it might be a mess. However, I might update the app a bit more because it's missing some features from the game. But then again, it's not inteded for live launch.

# Combo-Simulator
A combo sim app for a MMO RPG game "Naruto Online".

The purpose of this app is to simulate combo attacks that a certain lineup of characters is able to achieve due to synergy between them.
In this game, characters are called Ninjas. 

Each Ninja has a set of abilities. These abilites are Mystery, Attack, Chase (optional), Passive (optional).

The way combos are achieved is by Ninjas activating their Chase ability. Chase ability is triggered by "cause" actions.
Let's say some Ninja's Mystery ability knocks down the enemy, this enemy is now under "Knockdown" state. 
If any Ninja from your lineup has a Chase ability that chases a "Knockdown" target - that Chase will be activated.
After the Chase is activated, that Chase will put the enemy under another state, for example "High Float", the next ally will trigger their Chase and so on.

# Screenshots

#### Main page
![SimulatorPage1](https://i.imgur.com/vh9qpZO.png)
#### Main page
![SimulatorPage2](https://i.imgur.com/b8e5OIM.png)
#### List of characters
![NinjaListPage](https://i.imgur.com/YWXjNoc.png)
#### Create a character
![NinjaCreatePage](https://i.imgur.com/d1c8NaF.png)
#### Manage a character
![NinjaDetailsPage](https://i.imgur.com/O51tXYX.png)
#### Edit a character
![NinjaEditPage](https://i.imgur.com/YJxmVED.png)
#### List of all "chase" abilites
![ChaseListPage](https://i.imgur.com/JyCBZhv.png)