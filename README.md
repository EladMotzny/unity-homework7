# unity-homework7

This is a simple game about Booba and his friend or enemy Juan.
<pictures from game>







## Code:
[In this code we activate an animation](https://github.com/EladMotzny/unity-homework7/blob/cf9d06b9deb6f9286dd04f0c3576c900bd8be2c0/Conversation/Assets/Scripts/BoobaScript.cs#L44-L49)

When you want to print the text above Booba, [you'll use this piece of code](https://github.com/EladMotzny/unity-homework7/blob/cf9d06b9deb6f9286dd04f0c3576c900bd8be2c0/Conversation/Assets/Scripts/Dialogue.cs#L44-L72)
<GIF OF TEXT APPEARING>
 
 To make the user wait until the text is done and not press the buttons accidently, which could cause a bug, [We use SetActive function](https://github.com/EladMotzny/unity-homework7/blob/cf9d06b9deb6f9286dd04f0c3576c900bd8be2c0/Conversation/Assets/Scripts/Dialogue.cs#L77-L81)

To know which option we need to present the player we used [boolean flags and counters](https://github.com/EladMotzny/unity-homework7/blob/cf9d06b9deb6f9286dd04f0c3576c900bd8be2c0/Conversation/Assets/Scripts/Dialogue.cs#L14-L22) so we'll know exactly where the player is currently at.
