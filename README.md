# Basic Scoreboard System

This started as a copy from one of my other projects, BasicInventorySystem,
and that is clear in the source code as well.

The aim of this project is to create a simple scoreboard system that you can host yourself.
And I will try to host a website that you can use for your small projects also.

The principle is then, an API that you can do CRUD towards.
In the Create you need to input:
userName, scoreAmmount, gameID

And for Read you would need to ask for eiher one of these.
Update and Delete is something I think should not be on this API.
That is because I have not implemented an authorisation yet.


---

Feel free to open issues or clone/fork the project.

---

#### Prerequisites:

```diff

@@ Dotnet 7.0 SDK @@
@@ Knowledge of Dotnet @@
@@ MongoDB or other db (will require tweaks to code) @@

```
  
There is a run.ps1 that you could run to run both projects at once easier, will require editing to change directory to your project directory.
