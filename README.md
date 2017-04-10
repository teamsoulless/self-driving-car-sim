## Welcome to Udacity's Self-Driving Car Simulator 

This simulator was built for [Udacity's Self-Driving Car Nanodegree](https://udacity.com/drive), to teach students how to train cars how to navigate road courses using deep learning. See more [project details here](https://github.com/udacity/CarND-Behavioral-Cloning-P3).

All the assets in this repository require Unity. Please follow the instructions below for the full setup.

### Avaliable Game Builds (Precompiled builds of the simulator)

Instructions: Download the zip file, extract it and run the exectution file.

Version 2.1, 2/21/17

[Linux](https://drive.google.com/open?id=0B106X2hCBrwuRUMyUkpGZ2lPQXc)
[Mac](https://drive.google.com/open?id=0B106X2hCBrwudGtXUlJydUluVWc)

### Unity Simulator User Instructions

1. Clone the repository to your local directory, please make sure to use [Git LFS](https://git-lfs.github.com) to properly pull over large texture and model assets. 

2. Install the free game making engine [Unity](https://unity3d.com), if you dont already have it. Unity is necessary to load all the assets.

3. Load Unity, Pick load exiting project and choice the `self-driving-car-sim` folder.

4. Load up scenes by going to Project tab in the bottom left, and navigating to the folder Assets/1_SelfDrivingCar/Scenes. To load up one of the scenes, for example the Lake Track, double click the file LakeTrackTraining.unity. Once the scene is loaded up you can fly around it in the scene viewing window by holding mouse right click to turn, and mouse scroll to zoom.

5. Play a scene. Jump into game mode anytime by simply clicking the top play button arrow right above the viewing window.

6. View Scripts. Scripts are what make all the different mechanics of the simulator work and they are located in two different directories, the first is Assets/1_SelfDrivingCar/Scripts which mostly relate to the UI and socket connections. The second directory for scripts is Assets/Standard Assets/Vehicle/Car/Scripts and they control all the different interactions with the car.

7. Building a new track. You can easily build a new track by using the prebuilt road prefabs located in Assets/RoadKit/Prefabs click and drag the road prefab pieces onto the editor, you can snap road pieces together easily by using vertex snapping by holding down "v" and dragging a road piece close to another piece.

![Self-Driving Car Simulator](./sim_image.png)

["Kia Soul"](https://sketchfab.com/models/95f6b0ec50654c7099db3a34d2ce516f#) by [27films](https://sketchfab.com/271films) used under [CC BY 4.0](https://creativecommons.org/licenses/by/4.0/) / Use only body/shell on top of existing Unity Skycar chassis and update material to match Polysync Kia Soul from original.

![Kia Soul Skycar](./kiasoul.JPG)
