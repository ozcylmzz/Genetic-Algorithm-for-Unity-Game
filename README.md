# Genetic Algorithm for Unity Game
 
Content: A program designed in the Unity game engine that allows the game to be played from artificial intelligence algorithms using genetic algorithms.

Subject Description: To ensure that the game section is passed by using genetic algorithm. Players starting from the fixed point first follow randomly generated routes. Selecting, crossing and mutation functions from players who have reached the highest score are created paths that the next generation will follow. Generations that have reached the determined number of iterations are not produced from the beginning, they are trying to be cured. If the number of iterations is exceeded, random generations are generated again. These processes continue until the end of the game.

Conclusion: The mutation rate is an important factor for success. For example, when the mutation value is 0.5, it also fails good players because it mutates too much. Likewise, the mutation rate of 0.01 does not give good results according to the number of iterations we observe. When we select the mutation rate 0.1, it achieves success in shorter iterations. 
The distribution of obstacles is also a major factor affecting success. Very long iterations have also achieved success in cases when obstacles are close together and cover most of the road. 
The number of players is also another factor that influences success. As the number of players increases, the number of iterations decreases. 
On a partially difficult track, the number of achievement and iteration in the case operated with 20 players was as follows.

The game has achieved success in -> 12 iterations.

The game has achieved success in -> 17 iterations.

The game has achieved success in -> 7 iterations.

The game has achieved success in -> 29 iterations.

The game has achieved success in -> 30 iterations.

The game has not succeeded because it exceeded the number of iterations -> 50.

The game has not succeeded because it exceeded the number of iterations -> 50.

The game has achieved success in -> 2 iterations.

The game has not succeeded because it exceeded the number of iterations -> 50.

The game has achieved success in -> 31 iterations.
