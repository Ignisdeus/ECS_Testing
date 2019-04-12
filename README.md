# ECS_Testing

**Name:** Michael Carstairs

**Student Number:** C16707919

<h2> Description of the assignment </h2>
<p> 
This project displays a space battle of my own design. With some elements that inspired me from Star Wars the Old Republic. This project is programmed some elements of Hybrid ECS. This allows for more objects to be acting independently within the scene. 
</p>

<h2> Instructions </h2>

<p>
To use this project open the project, Start the game while in the "MainMenu" scene. 
You can then use the sliders on the right side of the screen to adjust the number of active ships to be spawned at the point of confrontation. 
When the player presses the play button the two slider bars will begin to deplete. 
When both bars have depleted the simulation will begin.
</p>

<h2>How it Works </h2>
<p>
This is a simulation that used Boid behaviours and hybrid ECS that enables unity to simultaneous control up to 600 independent Boids in the scene at any time. These Boids used a simple version of a state machine to enable more complex interactions within the scene. 
<h3>Setup Section</h3>
In the setup section of the simulation, the two mother ships use the seek behaviour to get to the centre of the game world(Vector3(0,0,0)). 
When the two ships are 20 units from the centre both spawn a predetermined amount of combat ships. These combat ships then line up in a set formation that is inspired by the eternal fleet in Star Wars the Knights of the Old Republic. After a few seconds, the smaller ship engages in combat. </br>
<h3>Combat Section</h3>
When the combat begins the two mother Ship cycle the combat area with using a path following Behaviour. While the combat boids have two main states Explore and Engage. 

|Behaviour| Effect |
|---------|--------|
|Explore  |Causes the boid to randomly pick a point within an ever decreasing sphear and seek this position. This sphear will reset to a larger size when it shrinks to a set point. Causing the battlefield to expand for a short amount of time.|
|Engage   |Causes the boid to ray cast forward if the ray cast hit a target that is not on the same side the health of the target is reduced. This health reduction has a small chance to perform a critical hit.While the target is alive the attacking ship will use a persue Behaviour.|
</p> 
<h2>What I am most proud of</h2>
<p>
 
|Mechanic| How it was done|
|--------|----------------|
|Camera Rail System|Using the path following behaviour on an Empty game object that has the camera presented to it. The camera has a basic look at behaviour on it with a public variable that can be used to place in the look at the target. This gave an effect similar to a camera on a rail system behaviour that can also be timed.|
|Formation|By using an array of Vector3's and an embedded for loop creating 300 points. One of these points then passed to each Instanced combat boid. the combat boids the first behaviour set up then causes the boid to get into this position before the fight starts.|
</p>

<h3> What I would Change</h3>
 <p>
  
|Mechanic|Issue|
|--------|----------------|
|Boid formation|For some unknown reason, some of the boids do not enter formation. Instead, they are following the explore behaviour. I have tried to fix this on multiple occasions but have not found the issue yet.|
|Camera Movement|Some of the camera movement is a little shaky this is due to the path following behaviour and the look at behaviour having some small issues. With more time I could fix this and make it much smoother.|
|Scene Updates|The planned scenes are different from the final implemented scenes due to lack of time. Giving more time these could be made to match the proposed scenes with more accuracy.|

</p>



<h1>Below this was the projected plan for the project</h1>

This document will outline the plan for this project, with scene progressions and behaviours found within each scene. 

**Scene 1:** 

![Scene_One](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_One.jpg)
 
-	Big carrier ship (Wonder) fly’s through space with a wonder behaviour. 
-	Camera (Path Follow) circles the carer ship.
-	Carrier ship (Seek) jumps to FTL.

**Scene 2-3:**

  ![Scene_Two](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_Two.jpg)
  ![Scene_Three](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_Three.jpg)
-	Camera (Seek Behaviour) follow the ship as the fly’s in hyperspace effect. 
-	Camera (remove All active Behaviours after a few seconds camera becomes inactive) slows down as ship disappears in a flash of light. 
 
**Scene 4:** 

 ![Scene_Four](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_Four.jpg)
-	Mother ship (Seek Behaviour) attacks the carrier ship knocking it out of hyperspace.
-	Camera shake at point of impact. 
-	Both ships are knocked out the hyperspace. 

**Scene 5:** 

 ![Scene_Five](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_Five.jpg)
-	Both ships start to cycle each other (Path following).
-	Lots of little ships begin to fight emerging form mother larger ships (Seek, obstacle avoidance, pursue, off set pursue).

**Scene 6:** 

 ![Scene_Six](https://github.com/Ignisdeus/ECS_Testing/blob/master/Images/Scene_Six.jpg)
-	Large ships launch bombers to destroy the other (Pursue).

**Scene 7:** 

-	Depending on the outcome of the attack runs one of the ships is destroyed and the other ship jumps to FTL to end the simulation. 
 
