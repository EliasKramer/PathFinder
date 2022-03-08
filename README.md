# PathFinder
A small algorithm to find a path in a 2 dimensional array
## In Settings.cs you can change some options
### The height and the width of the field you want to create
 ```CSharp
 public const int Height = 10; //set the value to a desired height
 public const int Width = 10; //set the value to a desired width
 ```
### The Start Code:
```CSharp
public const string StartVal = "SFFFFFFFFFBBBBBBFFFDFF"; //the code for generating the world
 ```
The world is a 2 dimensional array.
It is made of Fields and every Field can have a different Kind. <br>
A Kind can be:
* Free (you can go there) short form: F
* Blocked (you can not go there) short form: B
* Uncoverd (this field has been checked if it can be walked on) short form: C
* Start (the start where you start - must exist once) short form : S
* Destination (the point where the algorith shall find to) short form: D
* Path (fields that are marked as the calculated path) short form: P

In the start code you can only set to F,B,S,D
