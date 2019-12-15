# GameEngines
 Repo for GameEgines1

For my Unity assignment I'm still a little unsure of what I want to do but I'm leaning more towards making a procedural creature of some kind.
I'm more inclined to choose this as I want to learn more about procedural animation and see it as a good asset for future projects.
I may also include some VFX as I was looking into them over the summer for projects like this.
Another idea I have is to make a procedural segment of a world tht you can traverse with some form of hoverbike or a fluid like control system.
My ideas may change over time bit I'm more than likely going to work on an idea related to either of the ideas I've mentioned.

----
My concept for my assignment changed during my development process and going with the procedural idea I wanted to make a procedural audio visualiser. Doing some research into what kind of visual effect I wanted to do I settled on a wormhole effect. 

![](Images/wormhole_600.jpg)

![](Images/wormhole_sketch_LeahT.jpg)

----
The first step of creating a wormhole effect was to create a Torus which looked to be the best way to achieve my desired effect. A torus can be generated using this 3D sinusoid function:
x = (R + r cos v) cos u
y = (R + r cos v) sin u
z = r cos v

r is the radius of the pipe and R is the radius of the pipes curve. u is what defines the angle of the curve in radians. Finally v is the angle along the pipe

