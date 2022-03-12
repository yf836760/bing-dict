# bing-dict
Bing dictionary(http://cn.bing.com/dict) in command line.

## Add Enviroment variables
win + x
choose > system
chosse > advanced system setting
choose > Enviroment variables

## Add alias for current user
input $profile in termianl 
create that file
edit like following: New-Item -Path Alias:t -Value TransApple.exe


## Quickstart
```powershell
CommandType     Name                                               Version    Source
-----------     ----                                               -------    ------
Alias           trans -> TransApple.exe

PS C:\Users\yf836760> trans hitori
网络释义： 一个人；系都里；独自一人；
PS C:\Users\yf836760> trans emo
美['imo?]，英['i:m??]，n. 情感核摇滚乐； 网络释义： 情绪摇滚；情绪硬核(Emocore)；情绪核；
PS C:\Users\yf836760> trans kurai
网络释义： 仓井；九雷；克莱；
PS C:\Users\yf836760> trans hello world
n. 世界你好； 网络释义： 你好世界；别来无恙；哈罗；
PS C:\Users\yf836760> trans hello girl
na. 〈美口〉女电话接线员； 网络释义： 女话务员；女接线生；你好女孩；
```
# forked from Shawyeok/bing-dict
