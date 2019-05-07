#! /bin/bash

cd `dirname $0`
pwd
`dirname $0`/protoc --version
`dirname $0`/protoc -I=protos --csharp_out=protocol protos/RPC.proto protos/Game.proto
cp -R protocol ../BombServer/BombServer
cp -R protocol ../BombClient/Assets/Script/Network
# --proto_path=`dirname $0`/proto --csharp_out=`dirname $0`/src
#cd /Users/luwenyi/Work/GitHub/Unity/OutSpace_ET/Proto
#dotnet Proto2CS.dll