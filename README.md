# Open for contribution
Help.

# What is this?
Unity wont magically support your file explorer.
This plugin will open your file explorer depends on your options.

# Why wouldnt i write my own?
I recommend it because you will gain a lot of knowledge. This is something that you can create on your own.

# Advantages
- Uses unmanaged resources.
- You can store in ECS.
- Simple, you just gather path and do stuff with it.
- Depends on the platform, the thread will continue at the background. That allows your player to be online in-game.

# Usage
1. Well, just implement SimpleFilePathPicker in your project.
2. Use the "Extensions" one to use dynamic path picker.
3. So you create that dynamic path picker and an Options for it to define the file types, and you just call "pick" on it.
4. That is it.
