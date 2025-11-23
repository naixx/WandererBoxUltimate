This is an unofficial driver for WandererBox Ultimate v2.

## Motivation
Original ASCOM driver took about 15% CPU time on my MiniPC which was way too much.

I disassembled and reverse engineered it to fix the issues: suboptimal serial read/write, suboptimal ascom profile configuration read/write, outdated charts that are impossible to close, better history data.

So I've migrated driver as a native NINA driver, optimized serial read threshold, now profile is stored alpaca-style json in %programdata%/ascom.
New charts library. You can now close charts to tray.

Firstly I tried to edit bytecode directly in dll, or do some kind of weaving, reflection. That would produce easy to replace file. But I'm not a dotnet developer, so this failed. Next I decided to implement ASCOM driver via COM and man, this COM technology is real shit(not ascom directly). Finally, I decided to implement it as a native NINA driver, for that I had to mograte original code from 4.7 framework to dotnet 8. That was a challenge.  

all rights reserved by their respective owners
