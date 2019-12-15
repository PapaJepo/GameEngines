# GameEngines
 Repo for GameEngines1

**Initial Concept**

For my Unity assignment I'm still a little unsure of what I want to do but I'm leaning more towards making a procedural creature of some kind.
I'm more inclined to choose this as I want to learn more about procedural animation and see it as a good asset for future projects.
I may also include some VFX as I was looking into them over the summer for projects like this.
Another idea I have is to make a procedural segment of a world tht you can traverse with some form of hoverbike or a fluid like control system.
My ideas may change over time bit I'm more than likely going to work on an idea related to either of the ideas I've mentioned.

----
**Final Concept**

My concept for my assignment changed during my development process and going with the procedural idea I wanted to make a procedural audio visualiser. Doing some research into what kind of visual effect I wanted to do I settled on a wormhole effect. 

![](Images/wormhole_600.jpg)

![](Images/wormhole_sketch_LeahT.jpg)

----
**Development**

The first step of creating a wormhole effect was to create a Torus which looked to be the best way to achieve my desired effect. A torus can be generated using this 3D sinusoid function:
x = (R + r cos v) cos u
y = (R + r cos v) sin u
z = r cos v

r is the radius of the pipe and R is the radius of the pipes curve. u is what defines the angle of the curve in radians. Finally v is the angle along the pipe

The pipe is generated when its relative object wakes up. This generation creates the mesh of the Torus and sets its vertices and tirangles to in turn create the necessary quads. The Torus, as shown below, was generated using to vertices, A and B, along the angle of the curve u. I then moved along v to get the next pair and this continues until a full circle has been generated. 

![](Images/Torus-40-15.svg.png)

The current and previous points are assigned to the current quads vertices. After creating the first ring the triangles for the quads are intilized, a quad has two triangles which means it also has 6 vertices. To ensure we see the inside of the mesh I made sure to set the triangles to have the normals be flipped. Using the pipes amount of segments we move through each one copying 2 vertices from each previous rings quad.  

To generate the wormhole effect I don't need to use an entire Torus so I split the generated Torus into segments and using a random range give them a random rotation and angles to create the procedural effect that the wormhole is always moving in a different way. As the pipes move around the origin the first pipe is shifted in the array to become the last pipe generated. Each pipe after the first is parent to it to ensure that the pipes transforms don't degrade over time. When a segment ends the new pipe is shifted to move around the origin and reseting their position. The pipes curve angle is ued to detect the end of a pipe segment.

----

After creating the wormhole effect I wanted to add audio reactive objects to the scene. I resarched what ways people madd 3D visualisers and I settled on usinga ring of cubes to show the spectrum data of the audio. I also used shaders to displace the vertices of a sphere by the volume of the audio.

![](Images/maxresdefault.jpg)

![](Images/d_balls_wire.png)
