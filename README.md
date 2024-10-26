# Raining Objects Unity Game Project

## Description 
**Raining Objects** is a 2D Unity two-player game where players control a movable basket at the bottom of the screen, working together to collect objects. The objective is to catch as many falling fruits and vegetables as possible while avoiding misses. The game offers a challenging, fast-paced experience with increasing difficulty and limited lives.

![GUI_Raining_Objects](image-4.png)

> Enjoy the challenge, and try to beat your high score!

## Game Overview

### Scope
- **Playable Area**: 2D side-view perspective
- **Player Object**: Two movable baskets at the bottom of the screen
- **Falling Objects**: An infinite number of fruits and vegetables falls continuously from the top of the screen
- **Lives and Game Over Condition**: The players starts with 3 lives and the game ends when all lives are lost
- **Goal**: Catch as many fruits and vegetables as possible to score points and avoid losing all lives

### Game Mechanics

- **Object Dynamics**: Different fruits and vegetables continuously fall from the top of the screen.
- **Obstacles**: The player loses one life for each object missed.
- **Player Controls**: The two player controls a movable basket at the bottom of the screen
    - Player 1 Keys: `←` , `→`
    - Player 2 Keys: `A` , `D`

### Features
- **Scoring**: Points are awarded for each object successfully caught Infinite number of fruits falling from the top of the screen
- **Increasing Difficulty**: The speed or frequency of falling objects can increase over time, making the game more challenging

### Game Inspiration
- This game is inspired by ["It’s raining cubes"](https://medium.com/hyperskill/top-unity-projects-to-help-beginners-get-started-with-game-development-db4246d7d93a), a project that helps beginners get started with Unity game development.

## How to Run the Code

### Start the application (For Playing Only)

If you just want to play the game, download the pre-built version:

1. Download the Latest Build (usually a .zip or .rar file)
2. Extract the files into a folder of your choice
3. **Run the Game**: Open the folder `Raining-Objects-Game`, next open the folder `_Build` and then double-click on the executable file `Raining-Objects-Game-Multiplayer.exe` to start playing.

- > There is also a Singleplayer option available

### Run Project (For Development)
To run the project in Unity, follow these steps:

1. **Clone the Repository**: Open a terminal or command prompt and run:
   ```bash
   git clone https://github.com/JonnyPon/Raining-Objects-Game.git
   ```

2. **Open Unity Hub**: Launch Unity Hub, click on Open, and navigate to the raining-objects folder created by cloning the repository.
3. **Open Project**: Select the project folder and open it in Unity.
4. **Install Dependencies**: Unity may prompt you to install necessary packages or assets. Follow these prompts to ensure all dependencies are installed.
5. **Run the Game**: Once the project loads, you can play and test it by selecting the `Play Button` in Unity.

## Software
This project was created using Unity Hub 3.8.0. with `Unity Version 2022.3.4.2f1`.

## Licensing

This project is licensed under the terms of the MIT license.