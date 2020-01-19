# Moving Character in VR Game by outside
> Friday Team

> Github: https://github.com/hxtruong/control-in-vr-game-by-outside

This is a VR seminar in Game development and visualize subject.

This project forcus directly on demo a game using VR technology. In details, we make a VR game has a character (is player) in a fantasy world which is allow controlled outside by player. The story of game is simply moving character in VR environment using a third party device, In this case, I remote by other mobile.

The screemshot:
![Picture1](https://user-images.githubusercontent.com/24609363/72690015-741e8f80-3b4a-11ea-8fb9-35a465ebd301.png)
![Picture2](https://user-images.githubusercontent.com/24609363/72690016-741e8f80-3b4a-11ea-9d28-93957188eaac.png)
 <img src="https://user-images.githubusercontent.com/24609363/72690017-741e8f80-3b4a-11ea-9dd8-4155bd3d6de5.png" width="512">


## Member
 * 1612756 – Nguyễn Hữu Trường
 * 1612899 – Hoàng Xuân Trường
## Resource
 - __Slide__: http://bit.ly/2RzlSmC 
 - __APK build__: http://bit.ly/34sIWIn

 <img src="https://user-images.githubusercontent.com/24609363/72690018-74b72600-3b4a-11ea-8670-8eb66c092a28.png" width="128">

## Guide
This steps below will help you make VR game controlled by outside similary:

There are 2 two application need to build. 
- __Game__: a main charactor moving
1. Download Google VR SDK and import to project
2. Create charactor then put it in scene as normal unity game.
3. Read tutorial on Google VR SDK then set up and drag the necessary prefabs to scene (such as *GvrControllerMain*, *GvrControllerPointer*,...)
4. Recieve *tranform* information from __remote app__ then update tranform for charactor.

- __Remote app__: 
1. Design joystick button for moving
2. Connect to Game via local IP
3. Send *tranform* information to __game__ when interact with joystick.

### Core
Beside I use Google VR SDK to make a normal game to VR game (is basically I think in my native view), __UNet__ of unity is way to *send* and *recieve* package via local network (of course we must know IP each other to connect). The main game is considered like server and remote app like client which send information to server.

##  The end & Thank you :)
